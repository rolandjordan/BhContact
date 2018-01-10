import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ContactService } from '../../services/contact.service';
import { Contact } from '../../contract/contact';

@Component({
    selector: 'viewcontact',
    templateUrl: './viewcontact.component.html',
    providers: [ContactService]
})
export class ViewContactComponent {

    public contact: Contact;
    public isEditing: boolean;

    constructor(private service: ContactService, private route: ActivatedRoute, private router: Router) {
    }

    ngOnInit() {
        this.route
            .queryParams
            .subscribe(params => {
                this.service.getContact(params['id'])
                    .subscribe(result => {
                        if (!result) {
                            this.router.navigate(['/home']);
                        }
                        this.contact = result as Contact;
                    }, (error: Response) => {
                        if (error.status === 404) this.router.navigate(['/home']);
                    });
            });
    }

    deleteContact() {
        var result = confirm(`Want to delete ${this.contact.firstName} ${this.contact.lastName}?`);
        if (result) {
            this.service.deleteContact(this.contact.contactReferenceId)
                .subscribe(result => {
                    if (result) this.router.navigate(['/home']);
                }, error => console.error(error));
        }
    }

    editContact() {
        this.isEditing = true;
    }

    updateContact() {
        this.service.updateContact(this.contact)
            .subscribe(result => {
                this.contact = result as Contact;
                this.isEditing = false;
            }, (error: Response) => {
                if (error.status === 400) {
                    console.log(error.json());
                }
            });
    }
}
