// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function getUsers() {
    fetch('/api/users')
        .then(response => { return response.json() })
        .then(data => { console.log(data) })
        .catch(error => {console.error('Erreur lors de la requête :', error);
        })
}

function getUser(id) {
    fetch(`/api/users/${id}`)
        .then(response => { return response.json() })
        .then(data => { console.log(data) })
        .catch(error => {
            console.error('Erreur lors de la requête :', error);
        })
}

function addUser(email, password, firstname, lastname, phonenumber, isadmin) {
    var userData = {
        email: email,
        password: password,
        first_name: firstname,
        last_name: lastname,
        phone_number: phonenumber,
        is_admin: isadmin
    };

    // Effectuer la requête POST vers votre API
    console.log(userData);
    fetch('/api/users', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(userData)
    })
        .then(response => {           
            if (response.ok) {
                console.log('Utilisateur ajouté avec succès.');
                // Traiter la réponse de réussite si nécessaire
            } else {
                console.error('Erreur lors de l\'ajout de l\'utilisateur. Code de statut : ' + response.status);
                // Traiter la réponse d'erreur si nécessaire
            }
        })
        .catch(error => {
            console.error('Erreur lors de la requête :', error);
        });
}

function updateUser(id, email, password, firstname, lastname, phonenumber, isadmin) {
    var userData = {
        id: id,
        email: email,
        password: password,
        first_name: firstname,
        last_name: lastname,
        phone_number: phonenumber,
        is_admin: isadmin
    };

    // Effectuer la requête PUT vers votre API
    console.log(userData);
    fetch('/api/users', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(userData)
    })
        .then(response => {
            if (response.ok) {
                console.log('Utilisateur modifié avec succès.');
                // Traiter la réponse de réussite si nécessaire
            } else {
                console.error('Erreur lors de l\'ajout de l\'utilisateur. Code de statut : ' + response.status);
                // Traiter la réponse d'erreur si nécessaire
            }
        })
        .catch(error => {
            console.error('Erreur lors de la requête :', error);
        });
}

function deleteUser(id) {
    var userData = {
        id: id,
    };

    // Effectuer la requête PUT vers votre API
    console.log(userData);
    fetch(`/api/users/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(userData)
    })
        .then(response => {
            if (response.ok) {
                console.log('Utilisateur supprimé avec succès.');
                // Traiter la réponse de réussite si nécessaire
            } else {
                console.error('Erreur lors de l\'ajout de l\'utilisateur. Code de statut : ' + response.status);
                // Traiter la réponse d'erreur si nécessaire
            }
        })
        .catch(error => {
            console.error('Erreur lors de la requête :', error);
        });
}

function getAssos() {
    fetch('/api/associations')
        .then(response => { return response.json() })
        .then(data => { console.log(data) })
        .catch(error => {
            console.error('Erreur lors de la requête :', error);
        })
}

function getAsso(id) {
    fetch(`/api/associations/${id}`)
        .then(response => { return response.json() })
        .then(data => { console.log(data) })
        .catch(error => {
            console.error('Erreur lors de la requête :', error);
        })
}

function addAsso(name) {
    var assoData = {
        name: name
    };

    // Effectuer la requête POST vers votre API
    console.log(assoData);
    fetch('/api/associations', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(assoData)
    })
        .then(response => {
            if (response.ok) {
                console.log('Association ajouté avec succès.');
                // Traiter la réponse de réussite si nécessaire
            } else {
                console.error('Erreur lors de l\'ajout de l\'utilisateur. Code de statut : ' + response.status);
                // Traiter la réponse d'erreur si nécessaire
            }
        })
        .catch(error => {
            console.error('Erreur lors de la requête :', error);
        });
}

function updateAsso(id, name) {
    var assoData = {
        id: id,
        name: name
    };

    // Effectuer la requête PUT vers votre API
    console.log(assoData);
    fetch('/api/associations', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(assoData)
    })
        .then(response => {
            if (response.ok) {
                console.log('Association modifié avec succès.');
                // Traiter la réponse de réussite si nécessaire
            } else {
                console.error('Erreur lors de l\'ajout de l\'utilisateur. Code de statut : ' + response.status);
                // Traiter la réponse d'erreur si nécessaire
            }
        })
        .catch(error => {
            console.error('Erreur lors de la requête :', error);
        });
}

function deleteAsso(id) {
    var assoData = {
        id: id,
    };

    // Effectuer la requête PUT vers votre API
    console.log(assoData);
    fetch(`/api/associations/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(assoData)
    })
        .then(response => {
            if (response.ok) {
                console.log('Utilisateur supprimé avec succès.');
                // Traiter la réponse de réussite si nécessaire
            } else {
                console.error('Erreur lors de l\'ajout de l\'utilisateur. Code de statut : ' + response.status);
                // Traiter la réponse d'erreur si nécessaire
            }
        })
        .catch(error => {
            console.error('Erreur lors de la requête :', error);
        });
}



function getPostes() {
    fetch('/api/postes')
        .then(response => { return response.json() })
        .then(data => { console.log(data) })
        .catch(error => {
            console.error('Erreur lors de la requête :', error);
        })
}

function getPoste(id) {
    fetch(`/api/postes/${id}`)
        .then(response => { return response.json() })
        .then(data => { console.log(data) })
        .catch(error => {
            console.error('Erreur lors de la requête :', error);
        })
}

function addPoste(name, description) {
    var posteData = {
        name: name,
        description: description
    };

    // Effectuer la requête POST vers votre API
    console.log(posteData);
    fetch('/api/postes', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(posteData)
    })
        .then(response => {
            if (response.ok) {
                console.log('Poste ajouté avec succès.');
                // Traiter la réponse de réussite si nécessaire
            } else {
                console.error('Erreur lors de l\'ajout de l\'utilisateur. Code de statut : ' + response.status);
                // Traiter la réponse d'erreur si nécessaire
            }
        })
        .catch(error => {
            console.error('Erreur lors de la requête :', error);
        });
}

function updatePoste(id, name, description) {
    var posteData = {
        id: id,
        name: name,
        description: description
    };

    // Effectuer la requête PUT vers votre API
    console.log(posteData);
    fetch('/api/postes', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(posteData)
    })
        .then(response => {
            if (response.ok) {
                console.log('Poste modifié avec succès.');
                // Traiter la réponse de réussite si nécessaire
            } else {
                console.error('Erreur lors de l\'ajout de l\'utilisateur. Code de statut : ' + response.status);
                // Traiter la réponse d'erreur si nécessaire
            }
        })
        .catch(error => {
            console.error('Erreur lors de la requête :', error);
        });
}

function deletePoste(id) {
    var posteData = {
        id: id,
    };

    // Effectuer la requête PUT vers votre API
    console.log(posteData);
    fetch(`/api/postes/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(posteData)
    })
        .then(response => {
            if (response.ok) {
                console.log('Poste supprimé avec succès.');
                // Traiter la réponse de réussite si nécessaire
            } else {
                console.error('Erreur lors de l\'ajout de l\'utilisateur. Code de statut : ' + response.status);
                // Traiter la réponse d'erreur si nécessaire
            }
        })
        .catch(error => {
            console.error('Erreur lors de la requête :', error);
        });
}
