"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var core_2 = require("@angular/core");
var Book_1 = require("./Book");
var book_service_1 = require("./book.service");
require("rxjs/Rx");
var AppComponent = (function () {
    function AppComponent(serv) {
        this.serv = serv;
        this.books = new Array();
    }
    AppComponent.prototype.ngOnInit = function () {
        this.loadBooks();
    };
    //load books
    AppComponent.prototype.loadBooks = function () {
        var _this = this;
        this.serv.getBooks().subscribe(function (resp) {
            _this.books = resp.json();
        });
    };
    // add book
    AppComponent.prototype.addBook = function () {
        this.editedBook = new Book_1.Book(0, "", "", "", 0);
        this.books.push(this.editedBook);
        this.isNewRecord = true;
    };
    // edit book
    AppComponent.prototype.editBook = function (book) {
        this.editedBook = new Book_1.Book(book.Id, book.Name, book.Publisher, book.Author, book.Price);
    };
    // load template edit or read only
    AppComponent.prototype.loadTemplate = function (book) {
        if (this.editedBook && this.editedBook.Id == book.Id) {
            return this.editTemplate;
        }
        else {
            return this.readOnlyTemplate;
        }
    };
    // save book
    AppComponent.prototype.saveBook = function () {
        var _this = this;
        if (this.isNewRecord) {
            // add book
            this.serv.createBook(this.editedBook).subscribe(function (resp) {
                _this.statusMessage = 'Данные успешно добавлены',
                    _this.loadBooks();
            });
            this.isNewRecord = false;
            this.editedBook = null;
        }
        else {
            // update book
            this.serv.updateBook(this.editedBook.Id, this.editedBook).subscribe(function (resp) {
                _this.statusMessage = 'Данные успешно обновлены',
                    _this.loadBooks();
            });
            this.editedBook = null;
        }
    };
    // cansel edit
    AppComponent.prototype.cancel = function () {
        // delete last record if click cancel
        if (this.isNewRecord) {
            this.books.pop();
            this.isNewRecord = false;
        }
        this.editedBook = null;
    };
    // delete book
    AppComponent.prototype.deleteBook = function (book) {
        var _this = this;
        this.serv.deleteBook(book.Id).subscribe(function (resp) {
            _this.statusMessage = 'Данные успешно удалены',
                _this.loadBooks();
        });
    };
    return AppComponent;
}());
__decorate([
    core_1.ViewChild('readOnlyTemplate'),
    __metadata("design:type", core_1.TemplateRef)
], AppComponent.prototype, "readOnlyTemplate", void 0);
__decorate([
    core_1.ViewChild('editTemplate'),
    __metadata("design:type", core_1.TemplateRef)
], AppComponent.prototype, "editTemplate", void 0);
AppComponent = __decorate([
    core_2.Component({
        selector: 'my-app',
        template: "./app/app.component.html",
        providers: [book_service_1.BookService]
    }),
    __metadata("design:paramtypes", [book_service_1.BookService])
], AppComponent);
exports.AppComponent = AppComponent;
//# sourceMappingURL=app.component.js.map