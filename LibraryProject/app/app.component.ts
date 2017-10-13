import { TemplateRef, ViewChild } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { Book } from './Book';
import { BookService } from './book.service';
import { Headers, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/Rx';

@Component({
    selector: 'my-app',
    template: `./app/app.component.html`,
    providers: [BookService]
})
export class AppComponent implements OnInit {
    //type of template
    @ViewChild('readOnlyTemplate') readOnlyTemplate: TemplateRef<any>;
    @ViewChild('editTemplate') editTemplate: TemplateRef<any>;

    editedBook: Book;
    books: Array<Book>;
    isNewRecord: boolean;
    statusMessage: string;

    constructor(private serv: BookService) {
        this.books = new Array<Book>();
    }

    ngOnInit() {
        this.loadBooks();
    }

    //load books
    private loadBooks() {
        this.serv.getBooks().subscribe((resp: Response) => {
            this.books = resp.json();
        });
    }
    // add book
    addBook() {
        this.editedBook = new Book(0,"","","",0);
        this.books.push(this.editedBook);
        this.isNewRecord = true;
    }

    // edit book
    editBook(book: Book) {
        this.editedBook = new Book(book.Id, book.Name, book.Publisher, book.Author, book.Price);
    }
    // load template edit or read only
    loadTemplate(book: Book) {
        if (this.editedBook && this.editedBook.Id == book.Id) {
            return this.editTemplate;
        } else {
            return this.readOnlyTemplate;
        }
    }
    // save book
    saveBook() {
        if (this.isNewRecord) {
            // add book
            this.serv.createBook(this.editedBook).subscribe((resp: Response) => {
                this.statusMessage = 'Данные успешно добавлены',
                    this.loadBooks();
            });
            this.isNewRecord = false;
            this.editedBook = null;
        } else {
            // update book
            this.serv.updateBook(this.editedBook.Id, this.editedBook).subscribe((resp: Response) => {
                this.statusMessage = 'Данные успешно обновлены',
                    this.loadBooks();
            });
            this.editedBook = null;
        }
    }
    // cansel edit
    cancel() {
        // delete last record if click cancel
        if (this.isNewRecord) {
            this.books.pop();
            this.isNewRecord = false;
        }
        this.editedBook = null;
    }
    // delete book
    deleteBook(book: Book) {
        this.serv.deleteBook(book.Id).subscribe((resp: Response) => {
            this.statusMessage = 'Данные успешно удалены',
                this.loadBooks();
        });
    }
}