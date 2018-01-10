import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ContactService } from '../../services/contact.service';
import { Contact } from '../../contract/contact';

@Component({
    selector: 'addcontact',
    templateUrl: './addcontact.component.html',
    providers: [ContactService]
})
export class AddContactComponent {

    public contact: Contact;

    constructor(private service: ContactService, private route: ActivatedRoute, private router: Router) {
    }

    ngOnInit() {

        this.contact = {
            contactReferenceId: '',
            email: '',
            firstName: '',
            lastName: '',
            organization: '',
            phoneNumber: ''

        } as Contact;

    }

    addContact() {
        this.service.addContact(this.contact)
            .subscribe(result => {
                this.router.navigate(['/contact'],
                    {
                        queryParams: {
                            id: result.contactReferenceId
                        }
                    });
            }, (error: Response) => {
                if (error.status === 400) {
                    console.log(error.json());
                }
            });
    }
}