import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';

import { GetContactsComponent } from './components/contacts/getcontacts.component';
import { ViewContactComponent } from './components/contacts/viewcontact.component';
import { AddContactComponent } from './components/contacts/addcontact.component';


@NgModule({
    declarations: [
        AppComponent,
        ViewContactComponent,
        AddContactComponent,
        GetContactsComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: GetContactsComponent },
            { path: 'contact', component: ViewContactComponent },
            { path: 'add-contact', component: AddContactComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
