import React, { Component } from 'react';
import { GetContact, AddContact, UpdatedContact, DeleteContact } from './ContactsService';
import update from 'immutability-helper';


class ContactForm extends Component {

    constructor(props) {
        super(props);
        this.state = {
            contact: null
        };

        this.add = this.add.bind(this);
        this.update = this.update.bind(this);
        this.delete = this.delete.bind(this);
        this.updateContactState = this.updateContactState.bind(this);
        this.initComponent = this.initComponent.bind(this);
    }

    isEdit(contactId) {
        return Number.isInteger(parseInt(contactId));
    }


    add() {
        AddContact(this.state.contact).done((contact) => {
            alert('Contact added');
        });
    }
    update() {
        UpdatedContact(this.state.contact).done(() => {
            alert('Contact updated');
        });
    }
    delete() {
        DeleteContact(this.state.contact).done(() => {
            alert('Contact deleted');
        });
    }

    updateContactState(newContactState) {
        this.setState((prevState) => {
            var changedPropKey = Object.keys(newContactState)[0];
            var changedPropValue = newContactState[changedPropKey];

            newContactState[changedPropKey] = { $set: changedPropValue };
            
            var mergedContactState = update(prevState.contact, newContactState);

            return {
                contact:mergedContactState 
            };
        });
    }

    componentWillReceiveProps(nextProps) {
        this.initComponent(nextProps.params.id);
    }


    componentDidMount() {
        this.initComponent(this.props.params.id);
    }

    initComponent(contactId) {
        // If Editing
        if(this.isEdit(contactId)) {
            GetContact(contactId).done((contact) => {
                this.setState({
                    contact: contact
                });
            });
        }
        else { // If Adding
            this.setState({
                contact: { }
            });
        }
    }

    componentWillUnmount() {

    }


    render() {
        var contact = this.state.contact;

        console.log(this.state.contact);

        if(!contact) {
            return (
                <div>Nothing here!</div>
            );
        }

        return (
            <form onSubmit={this.isEdit(contact.id) ? this.update : this.add}>
                <h3>{this.isEdit(contact.id) ? 'Update Contact' : 'Add New Contact'}</h3>
                <div>
                    <label>
                        Name
                        <input placeholder="Name" type="text" value={contact.name ? contact.name : ''} onChange={(e) => this.updateContactState({ name: e.target.value })} required />
                    </label>
                </div>

                <div>
                    <label>
                        Nick Name
                        <input placeholder="Nick Name" type="text" value={contact.nickName ? contact.nickName : ''} onChange={(e) => this.updateContactState({ nickName: e.target.value })} />
                    </label>
                </div>

                <div>
                    <label>
                        Birthday
                        <input placeholder="Birthday" type="date" value={contact.birthday ? contact.birthday : ''} onChange={(e) => this.updateContactState({ birthday: e.target.value })} />
                    </label>
                </div>

                <div>
                    <label>
                        Job Title
                        <input placeholder="Job Title" type="text" value={contact.jobTitle ? contact.jobTitle : ''} onChange={(e) => this.updateContactState({ jobTitle: e.target.value })} />
                    </label>
                </div>

                <div>
                    <label>
                        Company
                        <input placeholder="Company" type="text" value={contact.company ? contact.company : ''} onChange={(e) => this.updateContactState({ company: e.target.value })} />
                    </label>
                </div>

                <div>
                    <label>
                        Phone Number
                        <input placeholder="Phone Number" type="tel" value={contact.phoneNumber ? contact.phoneNumber : ''} onChange={(e) => this.updateContactState({ phoneNumber: e.target.value })} />
                    </label>
                </div>

                <div>
                    <label>
                        Email Address
                        <input placeholder="Email Address" type="email" value={contact.emailAddress ? contact.emailAddress : ''} onChange={(e) => this.updateContactState({ emailAddress: e.target.value })} />
                    </label>
                </div>

                <div>
                    <label>
                        Address
                        <input placeholder="Address" type="text" value={contact.address ? contact.address : ''} onChange={(e) => this.updateContactState({ address: e.target.value })} />
                    </label>
                </div>

                <div>
                    <button type="submit">Save Contact</button>
                </div>
            </form>
        );
    }
}

export default ContactForm;