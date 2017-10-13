import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Response, Headers } from '@angular/http';
import { Book } from './Book';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class BookService {
    private url = "http://localhost:64269/api/books/"
    constructor(private http: Http) { }

    getBooks() {
        return this.http.get(this.url);
    }

    createBook(obj: Book) {
        const body = JSON.stringify(obj);
        let headers = new Headers({ 'Content-Type': 'application/json;charset=utf-8' });
        return this.http.post(this.url, body, { headers: headers });
    }
    updateBook(id: number, obj: Book) {
        let headers = new Headers({ 'Content-Type': 'application/json;charset=utf-8' });
        const body = JSON.stringify(obj);
        return this.http.put(this.url + '/' + id, body, { headers: headers });
    }
    deleteBook(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}