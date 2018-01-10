import { Component } from '@angular/core';
import { ContactService } from '../../services/contact.service';
import { Contact } from '../../contract/contact';

@Component({
    selector: 'getcontacts',
    templateUrl: './getcontacts.component.html',
    providers: [ContactService]
})
export class GetContactsComponent {

    private contactStore: Contact[];
    public contacts: Contact[];
    public search: string;

    constructor(private service: ContactService) {
    }

    ngOnInit() {
        this.service.getContacts().subscribe(result => {
            this.contacts = result as Contact[];
            this.sortContacts();
            this.contactStore = this.contacts;
        }, error => console.error(error));
    }

    onKey(event: any) {

        this.search = event.target.value.toLocaleLowerCase();

        if (this.search) {
            this.contacts = [];
            this.contactStore.forEach(c => {
                if (c.firstName.toLocaleLowerCase().indexOf(this.search) !== -1 ||
                    c.lastName.toLocaleLowerCase().indexOf(this.search) !== -1) {
                    this.contacts.push(c);
                }
            });
        } else {
            this.contacts = this.contactStore;
            this.sortContacts();
        }

    }

    sortContacts() {
        this.contacts = this.contacts.sort((a, b) => {
            var nameA = a.firstName.toLocaleLowerCase();
            var nameB = b.firstName.toLocaleLowerCase();
            if (nameA < nameB) {
                return -1;
            }
            if (nameA > nameB) {
                return 1;
            }

            return 0;
        });
    }
}