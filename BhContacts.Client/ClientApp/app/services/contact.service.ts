import { Injectable, isDevMode } from "@angular/core";
import { Contact } from '../contract/contact';
import { Http, Response } from "@angular/http";
import { Observable } from "rxjs/Observable";
import "rxjs/Rx";


@Injectable()
export class ContactService {
    private apiUrl: string = "http://localhost:5000"; //TODO: need a production URL here

    constructor(private http: Http) {
        if (isDevMode()) {
            this.apiUrl = "http://localhost:5000";
        }
    }

    getContact(id: string): Observable<Contact> {
        return this.http
            .get(`${this.apiUrl}/api/contacts/get-contact/${id}`)
            .map((response: Response) => {
                return <Contact>response.json();
            })
            .catch(this.handleError);
    }

    getContacts(): Observable<Contact[]> {
        return this.http
            .get(`${this.apiUrl}/api/contacts/get-all-contacts`)
            .map((response: Response) => {
                return <Contact[]>response.json();
            })
            .catch(this.handleError);
    }

    deleteContact(id: string): Observable<boolean> {

        return this.http
            .delete(`${this.apiUrl}/api/contacts/delete-contact/${id}`)
            .map((response: Response) => {
                return <boolean>response.json();
            })
            .catch(this.handleError);
    }

    updateContact(request: Contact): Observable<Contact> {
        return this.http
            .put(`${this.apiUrl}/api/contacts/update-contact/${request.contactReferenceId}`, request)
            .map((response: Response) => {
                return <Contact>response.json();
            })
            .catch(this.handleError);
    }

    addContact(request: Contact): Observable<Contact> {
        return this.http
            .post(`${this.apiUrl}/api/contacts/add-contact`, request)
            .map((response: Response) => {
                return <Contact>response.json();
            })
            .catch(this.handleError);
    }


    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error);
    }

}