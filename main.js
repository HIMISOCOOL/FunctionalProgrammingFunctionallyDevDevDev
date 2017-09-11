"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var Cat = /** @class */ (function () {
    function Cat(name, age) {
        this.age = 0;
        this.isHyperActive = true;
        this.hunger = 0;
        this.name = name;
        this.age = age || 0;
    }
    Cat.prototype.feed = function (food) {
        this.hunger -= food.value;
    };
    return Cat;
}());
var getSomeNames = function () { return [
    "Ashes",
    "Tiger",
    "Puss",
    "Smokey",
    "Misty",
    "Tigger",
    "Kitty",
    "Oscar",
    "Missy",
    "Max",
    "Ginger"
]; };
var getSomeCats = function () { return [
    new Cat("Ashes", 4),
    new Cat("Tiger", 2),
    new Cat("Puss", 3),
    new Cat("Smokey"),
    new Cat("Misty", 4),
    new Cat("Tigger", 10),
    new Cat("Kitty", 4),
    new Cat("Oscar", 8),
    new Cat("Missy", 4),
    new Cat("Max"),
    new Cat("Ginger", 4),
    new Cat("Ashes", 2),
    new Cat("Molly", 4),
    new Cat("Charlie", 4),
    new Cat("Tigger", 1),
    new Cat("Poppy", 10),
    new Cat("Oscar", 4),
    new Cat("Smudge", 13),
    new Cat("Millie", 4),
    new Cat("Daisy", 7),
    new Cat("Max", 4),
    new Cat("Jasper", 16),
    new Cat("Trevor")
]; };
/**
 * map is foreach but returns somthing!
 */
function ageCats(cats) {
    var newCats = [];
    for (var i = 0; i < cats.length; i++) {
        var cat = cats[i];
        cat.age += 1;
        newCats.push(cat);
    }
    return newCats;
}
function ageCatsF(cats) {
    return cats.map(function (c) {
        c.age += 1;
        return c;
    });
}
/**
 * Filter is a foreach with an if and returns somthing!
 */
function olderCats(cats) {
    var oldCats = [];
    for (var i = 0; i < cats.length; i++) {
        var cat = cats[i];
        if (cat.age > 5)
            oldCats.push(cat);
    }
    return oldCats;
}
function olderCatsF(cats) {
    return cats.filter(function (c) { return c.age > 5; });
}
/**
 * YOU CAN FITLER AND MAP IN ONE(ish) LINES!
 */
function nameOlderCats(cats) {
    var oldCats = [];
    for (var i = 0; i < cats.length; i++) {
        var cat = cats[i];
        if (cat.age > 5) {
            // this would technically mutate the cat for all time
            cat.isHyperActive = false;
            oldCats.push(cat);
        }
    }
    return oldCats;
}
function nameOlderCatsF(cats) {
    return cats.filter(function (c) { return c.age > 5; }).map(function (c) {
        c.isHyperActive = true;
        return c;
    });
}
/**
 * Calculating the average was never easier
 */
function averageAge(cats) {
    var total = 0;
    for (var i = 0; i < cats.length; i++) {
        var cat = cats[i];
        total += cat.age;
    }
    return total / cats.length;
}
function averageAgeF(cats) {
    return cats
        .map(function (c) { return c.age; })
        .reduce(function (prev, curr) { return prev + curr; }) / cats.length;
}
var ResultCommonLogic = /** @class */ (function () {
    function ResultCommonLogic(isFailure, error) {
        if (isFailure) {
            if (!error) {
                throw new TypeError("error: " + error + " must be a string message");
            }
        }
        else {
            if (error !== null) {
                throw new TypeError('There should be no error message for success');
            }
        }
        this.isFailure = isFailure;
        this._error = error;
    }
    Object.defineProperty(ResultCommonLogic.prototype, "isSuccess", {
        get: function () {
            return !this.isFailure;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ResultCommonLogic.prototype, "error", {
        get: function () {
            if (this.isSuccess)
                throw new TypeError('There is no error message for success');
            return this._error;
        },
        enumerable: true,
        configurable: true
    });
    return ResultCommonLogic;
}());
var Result = /** @class */ (function () {
    function Result(isFailure, error) {
        this._logic = new ResultCommonLogic(isFailure, error);
    }
    Object.defineProperty(Result.prototype, "isFailure", {
        get: function () {
            return this._logic.isFailure;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(Result.prototype, "isSuccess", {
        get: function () {
            return this._logic.isSuccess;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(Result.prototype, "error", {
        get: function () {
            return this._logic.error;
        },
        enumerable: true,
        configurable: true
    });
    Result.okResult = new Result(false, null);
    Result.ok = function () { return Result.okResult; };
    Result.err = function (error) { return new Result(true, error); };
    Result.okT = function (value) { return new ResultT(false, value, null); };
    Result.errT = function (error) { return new ResultT(true, null, error); };
    Result.firstErrOrOk = function () {
        var results = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            results[_i] = arguments[_i];
        }
        for (var _a = 0, results_1 = results; _a < results_1.length; _a++) {
            var result = results_1[_a];
            if (result.isFailure)
                return Result.err(result.error);
        }
        return Result.ok();
    };
    Result.combine = function (errorMessagesSeparator) {
        if (errorMessagesSeparator === void 0) { errorMessagesSeparator = ','; }
        var results = [];
        for (var _i = 1; _i < arguments.length; _i++) {
            results[_i - 1] = arguments[_i];
        }
        var failedResults = results.filter(function (x) { return x.isFailure; });
        if (!failedResults.length)
            return Result.ok();
        var errorMessage = failedResults.map(function (x) { return x.error; }).join(errorMessagesSeparator);
        return Result.err(errorMessage);
    };
    Result.combineT = function (errorMessagesSeparator) {
        if (errorMessagesSeparator === void 0) { errorMessagesSeparator = ','; }
        var results = [];
        for (var _i = 1; _i < arguments.length; _i++) {
            results[_i - 1] = arguments[_i];
        }
        var untyped = results.map(function (r) { return r; });
        return Result.combine.apply(Result, [errorMessagesSeparator].concat(untyped));
    };
    return Result;
}());
exports.Result = Result;
exports.ok = Result.okT;
exports.err = Result.errT;
var ResultT = /** @class */ (function (_super) {
    __extends(ResultT, _super);
    function ResultT(isFailure, value, error) {
        var _this = _super.call(this, isFailure, error) || this;
        if (!isFailure && value == null) {
            throw new TypeError("value: " + value + " must not be undefined or null for successes");
        }
        _this._value = value;
        return _this;
    }
    Object.defineProperty(ResultT.prototype, "value", {
        get: function () {
            if (this.isFailure) {
                throw new TypeError('There is no value for failure.');
            }
            return this._value;
        },
        enumerable: true,
        configurable: true
    });
    return ResultT;
}(Result));
exports.ResultT = ResultT;
/**
 * result makes some thing easier, requires a package from npm :( OR you can write your own, like me
 */
var CommandService = /** @class */ (function () {
    function CommandService() {
        this.undoStack = [];
        this.redoStack = [];
    }
    CommandService.prototype.clear = function () {
        this.undoStack = [];
        this.redoStack = [];
    };
    CommandService.prototype.undo = function () {
        var command = this.undoStack.pop();
        if (command !== null) {
            command.undo();
            this.redoStack.push(command);
            return;
        }
        throw new Error('No command found to undo');
    };
    CommandService.prototype.redo = function () {
        var command = this.redoStack.pop();
        if (command !== null) {
            command.execute();
            this.undoStack.push(command);
            return;
        }
        throw new Error('No command found to redo');
    };
    CommandService.prototype.push = function (command) {
        command.execute();
        this.undoStack.push(command);
        this.redoStack = [];
    };
    return CommandService;
}());
var CommandServiceF = /** @class */ (function () {
    function CommandServiceF() {
        this.undoStack = [];
        this.redoStack = [];
    }
    CommandServiceF.prototype.clear = function () {
        this.undoStack = [];
        this.redoStack = [];
    };
    CommandServiceF.prototype.undo = function () {
        var _this = this;
        var undoInternal = function (command) {
            var result = command.undo();
            _this.redoStack.push(command);
            return result;
        };
        var command = this.undoStack.pop();
        return command
            ? undoInternal(command)
            : exports.err('No command found to undo');
    };
    CommandServiceF.prototype.redo = function () {
        var _this = this;
        var redoInternal = function (command) {
            var result = command.execute();
            _this.undoStack.push(command);
            return result;
        };
        var command = this.redoStack.pop();
        return command
            ? redoInternal(command)
            : exports.err('No command found to redo');
    };
    CommandServiceF.prototype.push = function (command) {
        var result = command.execute();
        this.undoStack.push(command);
        this.redoStack = [];
        return result;
    };
    return CommandServiceF;
}());
/**
 * Using local functions can help make code more readable
 */
var BadMan = /** @class */ (function () {
    function BadMan() {
    }
    BadMan.prototype.feedCats = function (cats) {
        var stillHungry = [];
        for (var i = 0; i < cats.length; i++) {
            var catfood = this.foodService.getCatFood(new Date());
            var cat = cats[i];
            cat.feed(catfood);
            if (cat.hunger > 2) {
                stillHungry.push(cat);
            }
        }
        return stillHungry;
    };
    return BadMan;
}());
var GoodMan = /** @class */ (function () {
    function GoodMan() {
    }
    GoodMan.feedCats = function (cats, foodService, today) {
        cats.forEach(function (cat) { return cat.feed(foodService.getCatFood(today)); });
        return cats.filter(function (c) { return c.hunger > 2; });
    };
    GoodMan.feedCatsBetter = function (cats, foodService, today) {
        var feedCat = function (cat) { return cat.feed(foodService.getCatFood(today)); };
        var catStillHungry = function (cat) { return cat.hunger > 2; };
        cats.forEach(feedCat);
        return cats.filter(catStillHungry);
    };
    return GoodMan;
}());
/**
 * Inline if (ternary operator) for no mutation if statements
 */
var IfElse = /** @class */ (function () {
    function IfElse() {
        /**
         * Instance function non mutating if
         */
        this.inspectCatsIFOther = function (cats) {
            return cats.some(function (c) { return c.isHyperActive; })
                ? 'We got a hyper active cat!'
                : 'We are all green here sir';
        };
    }
    /**
     * static mutating if
     * @param cats
     */
    IfElse.inspectCats = function (cats) {
        var result = '';
        if (cats.some(function (c) { return c.isHyperActive; })) {
            result = 'We got a hyper active cat!';
        }
        else {
            result = 'We are all green here sir';
        }
        return result;
    };
    /**
     * static non mutating if
     * @param cats
     */
    IfElse.inspectCatsF = function (cats) {
        return cats.some(function (c) { return c.isHyperActive; })
            ? 'We got a hyper active cat!'
            : 'We are all green here sir';
    };
    /**
     * Instance method non mutating if
     * @param cats
     */
    IfElse.prototype.inspectCatsIF = function (cats) {
        return cats.some(function (c) { return c.isHyperActive; })
            ? 'We got a hyper active cat!'
            : 'We are all green here sir';
    };
    /**
     * better looking static no mutating if
     */
    IfElse.inspectCatsFOther = function (cats) {
        return cats.some(function (c) { return c.isHyperActive; })
            ? 'We got a hyper active cat!'
            : 'We are all green here sir';
    };
    return IfElse;
}());
var partialCats = /** @class */ (function () {
    function partialCats() {
    }
    partialCats.prototype.doWorkWithCats = function () {
        var names = getSomeNames();
        var cats = partialCats.getCatsByName(names)(getSomeCats());
        var getCatsOlderThan10 = partialCats.getCatsOlderThan(10);
        // some other work
        var oldCats = getCatsOlderThan10(cats);
    };
    partialCats.getCatsByName = function (names) { return function (cats) {
        return cats.filter(function (c) { return names.includes(c.name); });
    }; };
    partialCats.getCatsOlderThan = function (age) { return function (cats) {
        return cats.filter(function (c) { return c.age >= age; });
    }; };
    return partialCats;
}());
