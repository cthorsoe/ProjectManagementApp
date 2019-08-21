import React, { Component } from 'react';

export class PwGen extends Component {
    static displayName = PwGen.name;

    constructor(props) {
        super(props);
        this.state = {
            password: "",
            encryptedPassword: undefined,
            loading: false,
            getHashPw: "",
            getHashSalt: "",
        };

        this.passwordChanged = this.passwordChanged.bind(this);
        this.submitPassword = this.submitPassword.bind(this);
        this.getHashValue = this.getHashValue.bind(this);
        this.hashPasswordChanged = this.hashPasswordChanged.bind(this);
        this.hashSaltChanged = this.hashSaltChanged.bind(this);
    }

    passwordChanged(event) {
        this.setState({ password: event.target.value });
    }
    submitPassword(event) {
        event.preventDefault();
        let body = {
            input: this.state.password
        };
        var url = 'api/PasswordEncrypter';

        fetch(url, {
            method: 'POST', // or 'PUT'
            body: JSON.stringify(body), // data can be `string` or {object}!
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(res => res.json())
        .then(response => console.log('Success:', JSON.stringify(response)))
        .catch(error => console.error('Error:', error));
    }

    getHashValue(event) {
        event.preventDefault();
        let body = {
            input: this.state.getHashPw,
            salt: this.state.getHashSalt
        };
        var url = 'api/PasswordEncrypter/GetHash';

        fetch(url, {
            method: 'POST', // or 'PUT'
            body: JSON.stringify(body), // data can be `string` or {object}!
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(res => res.json())
            .then(response => console.log('Success:', response))
            .catch(error => console.error('Error:', error));
    }


    hashPasswordChanged(event) {
        this.setState({ getHashPw: event.target.value });
    }

    hashSaltChanged(event) {
        this.setState({ getHashSalt: event.target.value });
    }

    render() {
        let password = this.state.encryptedPassword !== undefined ? this.state.encryptedPassword : "";
        return (
            <div>
                <h1>Pw Gen</h1>
                <p>Input password</p>
                <form onSubmit={this.submitPassword}>
                    <input type="text" value={this.state.password} onChange={this.passwordChanged} className="form-control" />
                    <input type="submit" value="Krypter Password" className="btn btn-primary" />
                </form>


                <form onSubmit={this.getHashValue}>
                    <input type="text" value={this.state.getHashPw} onChange={this.hashPasswordChanged} className="form-control" />
                    <input type="text" value={this.state.getHashSalt} onChange={this.hashSaltChanged} className="form-control" />
                    <input type="submit" value="Hent Hash" className="btn btn-primary" />
                </form>
            </div>
        );
    }
}
