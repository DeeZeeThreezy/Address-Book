export function GetContacts() {
    return $.get('api/contacts', (contacts) => {
        return contacts;
    });
};

export function GetContact(id) {
    return $.get(`api/contacts/${id}`, (contact) => {
        return contact;
    });
};

export function AddContact(newContact) {
    return $.post('api/contacts', newContact, (savedContact) => {
        return savedContact;
    });
};

export function UpdatedContact(updatedContact) {

    return $.ajax({
        type: 'PUT',
        url: `api/contacts/${updatedContact.id}`,
        contentType: "application/json",
        data: JSON.stringify(updatedContact)
    });
};

export function DeleteContact(updatedContact) {

    return $.ajax({
        type: 'DELETE',
        url: `api/contacts/${updatedContact.id}`
    });
};