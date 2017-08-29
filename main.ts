class Cat {
    public age: number = 0;
    public readonly name: string;
    public isHyperActive: boolean = true;
    public hunger: number;
    public feed(food) {
        this.hunger -= food.value;
    }
    constructor(name: string) {
        this.name = name;
    }
}
function ageCats(cats: Cat[]) {
    let newCats = [];
    for (let i = 0; i < cats.length; i++) {
        let cat = cats[i];
        cat.age += 1;
        newCats.push(cat);
    }
    return newCats;
}

function ageCatsF(cats: Cat[]) {
    return cats.map(c => {
        c.age += 1;
        return c;
    });
}

/**
 * map is foreach but returns somthing!
 */

function olderCats(cats: Cat[]) {
    let oldCats = [];
    for (let i = 0; i < cats.length; i++) {
        let cat = cats[i];
        if (cat.age > 5) oldCats.push(cat);
    }
    return oldCats;
}

function olderCatsF(cats: Cat[]) {
    return cats.filter(c => c.age > 5);
}

/**
 * Filter is a foreach with an if and returns somthing!
 */

function nameOlderCats(cats: Cat[]) {
    let oldCats = [];
    for (let i = 0; i < cats.length; i++) {
        let cat = cats[i];
        if (cat.age > 5) {
            // this would technically mutate the cat for all time
            cat.isHyperActive = false;
            oldCats.push(cat);
        }
    }
    return oldCats;
}

function nameOlderCatsF(cats: Cat[]) {
    return cats.filter(c => c.age > 5).map(c => {
        c.isHyperActive = true;
        return c;
    });
}

/**
 * YOU CAN FITLER AND MAP IN ONE(ish) LINES!
 */

function averageAge(cats: Cat[]) {
    let total = 0;
    for (let i = 0; i < cats.length; i++) {
        let cat = cats[i];
        total += cat.age;
    }
    return total / cats.length;
}

function averageAgeF(cats: Cat[]) {
    return cats
        .map(c => c.age)
        .reduce((prev, curr) => prev + curr) / cats.length;
}

/**
 * Calculating the average was never easier
 */

class ResultCommonLogic {
    public readonly isFailure: boolean;
    public get isSuccess() {
        return !this.isFailure;
    }

    private readonly _error: string;

    public get error() {
        if (this.isSuccess) throw new TypeError('There is no error message for success');
        return this._error;
    }

    constructor(
        isFailure: boolean,
        error: string
    ) {
        if (isFailure) {
            if (!error) {
                throw new TypeError(`error: ${error} must be a string message`);
            }
        } else {
            if (error !== null) {
                throw new TypeError('There should be no error message for success');
            }
        }
        this.isFailure = isFailure;
        this._error = error;
    }
}

export class Result {
    private static readonly okResult: Result = new Result(false, null);

    private readonly _logic: ResultCommonLogic;

    public get isFailure() {
        return this._logic.isFailure;
    }

    public get isSuccess() {
        return this._logic.isSuccess;
    }

    public get error() {
        return this._logic.error;
    }

    constructor(
        isFailure: boolean,
        error: string
    ) {
        this._logic = new ResultCommonLogic(isFailure, error);
    }

    public static ok = () => Result.okResult;

    public static err = (error: string) => new Result(true, error);

    public static okT = <T>(value: T) => new ResultT<T>(false, value, null);

    public static errT = <T>(error: string) => new ResultT<T>(true, null, error);

    public static firstErrOrOk = (...results: Result[]) => {
        for (const result of results) {
            if (result.isFailure) return Result.err(result.error);
        }
        return Result.ok();
    }

    public static combine = (errorMessagesSeparator = ',', ...results: Result[]) => {
        const failedResults = results.filter(x => x.isFailure);
        if (!failedResults.length) return Result.ok();

        const errorMessage = failedResults.map(x => x.error).join(errorMessagesSeparator);
        return Result.err(errorMessage);
    }

    public static combineT = <T>(errorMessagesSeparator = ',', ...results: ResultT<T>[]) => {
        const untyped = results.map(r => r as Result);
        return Result.combine(errorMessagesSeparator, ...untyped);
    }
}

export const ok = Result.okT;
export const err = Result.errT;

export class ResultT<T> extends Result {

    private readonly _value: T;

    public get value() {
        if (this.isFailure) {
            throw new TypeError('There is no value for failure.');
        }
        return this._value;
    }

    constructor(
        isFailure: boolean,
        value: T,
        error: string
    ) {
        super(isFailure, error);
        if (!isFailure && value == null) {
            throw new TypeError(`value: ${value} must not be undefined or null for successes`);
        }
        this._value = value;
    }
}


class CommandService {
    undoStack = [];
    redoStack = []

    clear() {
        this.undoStack = [];
        this.redoStack = [];
    }

    undo() {
        let command = this.undoStack.pop();
        if (command !== null) {
            command.undo();
            this.redoStack.push(command);
            return;
        }
        throw new Error('No command found to undo');
    }

    redo() {
        let command = this.redoStack.pop();
        if (command !== null) {
            command.execute();
            this.undoStack.push(command);
            return;
        }
        throw new Error('No command found to redo');
    }

    push(command) {
        command.execute();
        this.undoStack.push(command);
        this.redoStack = [];
    }
}

class CommandServiceF {
    undoStack = [];
    redoStack = [];

    constructor() { }

    clear() {
        this.undoStack = [];
        this.redoStack = [];
    }

    undo(): Result {
        const undoInternal = (command) => {
            const result = command.undo();
            this.redoStack.push(command);
            return result;
        };
        const command = this.undoStack.pop();
        return command
            ? undoInternal(command)
            : err('No command found to undo');
    }

    redo(): Result {
        const redoInternal = (command) => {
            const result = command.execute();
            this.undoStack.push(command);
            return result;
        };
        const command = this.redoStack.pop();
        return command
            ? redoInternal(command)
            : err('No command found to redo');
    }

    push(command): Result {
        const result = command.execute();
        this.undoStack.push(command);
        this.redoStack = [];
        return result;
    }
}

/**
 * result makes some thing easier, requires a package from npm :( OR you can write your own, like me
 */


class BadMan {
    public foodService;
    constructor() {

    }

    feedCats(cats: Cat[]) {
        let stillHungry = [];
        for (let i = 0; i < cats.length; i++) {
            let catfood = this.foodService.getCatFood(new Date());
            let cat = cats[i];
            cat.feed(catfood);

            if (cat.hunger > 2) {
                stillHungry.push(cat);
            }
        }
        return stillHungry;
    }
}

class GoodMan {
    public static feedCats(cats: Cat[], foodService, today: Date) {
        cats.forEach((cat: Cat) => cat.feed(foodService.getCatFood(today)));
        return cats.filter(c => c.hunger > 2);
    }

    public static feedCatsBetter(cats: Cat[], foodService, today: Date) {
        const feedCat = (cat: Cat) => cat.feed(foodService.getCatFood(today));
        cats.forEach(feedCat);
        return cats.filter(c => c.hunger > 2);
    }
}

class Chess {

    public static setupBoard() {
        // make white pawns
        // make black pawns
        // place white pawns
        // place black pawns
    }
}