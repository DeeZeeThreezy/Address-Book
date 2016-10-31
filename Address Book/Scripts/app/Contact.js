import React, { Component } from 'react';

class Contact extends Component {
    render() {
        var contact = this.props.contact;

        if(!contact) {
            return (
                <div>Nothing here!</div>
            );
        }


        return (
            <div>
                <h5>{contact.nickName}</h5>
                <p>{contact.name}</p>
            </div>
        );
    }
}

export default Contact;