import React, { Component } from 'react';
import { Link } from 'react-router';

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
                <Link to={"/contact/" + contact.id}></Link>
                <h5>{contact.nickName}</h5>
                <p>{contact.name}</p>
            </div>
        );
    }
}

export default Contact;