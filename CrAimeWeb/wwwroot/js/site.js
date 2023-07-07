// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.



// Write your JavaScript code.

const api = axios.create({
    baseURL: "/"
})

api.interceptors.request.use((config) => {
    config.headers["Content-Type"] = "application/json";
    return config;
})

function getUsers() {
    return axios.get('/api/users')
        .catch(error => {
            console.error('Erreur lors de la requête :', error);
            throw error;
        });
}

function getUser(id) {
    return axios.get(`/api/users/${id}`)
        .catch(error => {
            console.error('Erreur lors de la requête :', error);
            throw error;
        });
}

function addUser() {
    const email = document.getElementById("email").value;
    const password = document.getElementById("password").value;
    const firstname = document.getElementById("description").value;
    const lastname = document.getElementById("start_date").value;
    const phonenumber = document.getElementById("end_date").value;
    const isadmin = document.getElementById("isadmin").value;
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









function getEvents() {
    return axios.get('/api/evenements')
        .catch(error => {
            console.error('Erreur lors de la requête :', error);
        })
}

function getEvent(id) {
    return axios.get(`/api/evenements/${id}`)
        .catch(error => {
            console.error('Erreur lors de la requête :', error);
        })
}

async function addEvent() {
    const title = document.getElementById("title").value;
    const type = document.getElementById("type").value;
    const description = document.getElementById("description").value;
    const start_date = document.getElementById("start_date").value;
    const end_date = document.getElementById("end_date").value;
    var eventData = {
        title: title,
        type: type,
        description: description,
        start_date: start_date,
        end_date: end_date
    };

    // Effectuer la requête POST vers votre API
    console.log(eventData);
    const res = await api.post('/api/evenements', eventData)
        .catch(error => {
            console.error('Erreur lors de l\'ajout de l\'utilisateur. Code de statut : ' + error);
        })
        console.log('Event ajouté avec succès.');
}

function updateEvent(id, title, type, description, start_date, end_date) {
    var eventData = {
        id: id,
        title: title,
        type: type,
        description: description,
        start_date: start_date,
        end_date: end_date
    };

    // Effectuer la requête PUT vers votre API
    console.log(eventData);
    fetch('/api/evenements', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(eventData)
    })
        .then(response => {
            if (response.ok) {
                console.log('Event modifié avec succès.');
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

function deleteEvent(id) {
    var eventData = {
        id: id,
    };

    // Effectuer la requête PUT vers votre API
    console.log(eventData);
    fetch(`/api/evenements/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(eventData)
    })
        .then(response => {
            if (response.ok) {
                console.log('Event supprimé avec succès.');
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












function getPartenaires() {
    return axios.get('/api/partenaires')
        .catch(error => {
            console.error('Erreur lors de la requête :', error);
            throw error;
        });
}

function getPartenaire(id) {
    return axios.get(`/api/partenaires/${id}`)
        .catch(error => {
            console.error('Erreur lors de la requête :', error);
        })
}

async function addPartenaire() {
    const name = document.getElementById("name").value;
    const type = document.getElementById("type").value;
    const contact_phone = document.getElementById("phone").value;
    const contact_email = document.getElementById("email").value;
    var partenaireData = {
        name: name,
        type: type,
        contact_phone: contact_phone,
        contact_email: contact_email
    };

    // Effectuer la requête POST vers votre API
    console.log(partenaireData);
    const res = await api.post('/api/partenaires', partenaireData)
        .catch(error => {
            console.error('Erreur lors de l\'ajout de l\'utilisateur. Code de statut : ' + error);
        })
    console.log('Event ajouté avec succès.');
}


function updatePartenaire(id, name, type, contact_phone, contact_email) {
    var partenaireData = {
        id: id,
        name: name,
        type: type,
        contact_phone: contact_phone,
        contact_email: contact_email
    };

    // Effectuer la requête PUT vers votre API
    console.log(partenaireData);
    fetch('/api/partenaires', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(partenaireData)
    })
        .then(response => {
            if (response.ok) {
                console.log('Partenaire modifié avec succès.');
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

function deletePartenaire(id) {
    var partenaireData = {
        id: id,
    };

    // Effectuer la requête PUT vers votre API
    console.log(partenaireData);
    fetch(`/api/partenaires/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(partenaireData)
    })
        .then(response => {
            if (response.ok) {
                console.log('Partenaire supprimé avec succès.');
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








function getRegles() {
    fetch('/api/regles')
        .then(response => { return response.json() })
        .then(data => { console.log(data) })
        .catch(error => {
            console.error('Erreur lors de la requête :', error);
        })
}

function getRegle(id) {
    fetch(`/api/regles/${id}`)
        .then(response => { return response.json() })
        .then(data => { console.log(data) })
        .catch(error => {
            console.error('Erreur lors de la requête :', error);
        })
}

function addRegle(description) {
    var reglesData = {
        description:description
    };

    // Effectuer la requête POST vers votre API
    console.log(reglesData);
    fetch('/api/regles', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(reglesData)
    })
        .then(response => {
            if (response.ok) {
                console.log('Regle ajouté avec succès.');
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

function updateRegle(id, description) {
    var reglesData = {
        id: id,
        description: description
    };

    // Effectuer la requête PUT vers votre API
    console.log(reglesData);
    fetch('/api/regles', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(reglesData)
    })
        .then(response => {
            if (response.ok) {
                console.log('Regle modifié avec succès.');
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

function deleteRegle(id) {
    var reglesData = {
        id: id,
    };

    // Effectuer la requête PUT vers votre API
    console.log(reglesData);
    fetch(`/api/regles/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(reglesData)
    })
        .then(response => {
            if (response.ok) {
                console.log('Regle supprimé avec succès.');
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










function getStocks() {
    return axios.get('/api/stocks')        
        .catch(error => {
            console.error('Erreur lors de la requête :', error);
        })
}

function getStock(id) {
    return axios.get(`/api/stocks/${id}`)
        .catch(error => {
            console.error('Erreur lors de la requête :', error);
        })
}

function addStock(name, quantity, min_quantity, max_quantity, measure_unit) {
    var stocksData = {
        name: name,
        quantity: quantity,
        min_quantity: min_quantity,
        max_quantity: max_quantity,
        measure_unit: measure_unit
    };

    // Effectuer la requête POST vers votre API
    console.log(stocksData);
    fetch('/api/stocks', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(stocksData)
    })
        .then(response => {
            if (response.ok) {
                console.log('Stock ajouté avec succès.');
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

function updateStock(id, name, quantity, min_quantity, max_quantity, measure_unit) {
    var stocksData = {
        id: id,
        name: name,
        quantity: quantity,
        min_quantity: min_quantity,
        max_quantity: max_quantity,
        measure_unit: measure_unit
    };

    // Effectuer la requête PUT vers votre API
    console.log(stocksData);
    fetch('/api/stocks', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(stocksData)
    })
        .then(response => {
            if (response.ok) {
                console.log('Stock modifié avec succès.');
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

function deleteStock(id) {
    var stocksData = {
        id: id,
    };

    // Effectuer la requête PUT vers votre API
    console.log(stocksData);
    fetch(`/api/stocks/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(stocksData)
    })
        .then(response => {
            if (response.ok) {
                console.log('Stock supprimé avec succès.');
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