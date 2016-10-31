import React, { Component } from 'react';

class ContactInfo extends Component {
    render() {
        var contact = this.props.contact;

        if(!contact) {
            return (
                <div>
                    Nothing here!
                    <h4>Contact Info: {this.props.params.id}</h4>
                </div>
            );
        }


        return (
            <div>
                <h4>Contact Info: {this.props.params.id}</h4>
                <h5>{contact.nickName}</h5>
                <p>{contact.name}</p>
            </div>
        );
    }
}

export default ContactInfo;