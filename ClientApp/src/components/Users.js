import React, { Component } from 'react';

export class Users extends Component {
    static displayName = Users.name;

    constructor(props) {
        super(props);
        this.state = { users: [], loading: true };

        fetch('api/user')
            .then(response => response.json())
            .then(data => {
                this.setState({ users: data, loading: false });
            });
    }

    static renderUsersTable(users) {
        return (
            <table className='table table-striped'>
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Username</th>
                        <th>Email</th>
                        <th>Created</th>
                    </tr>
                </thead>
                <tbody>
                    {users.map(user =>
                        <tr key={user.id}>
                            <td>{user.id}</td>
                            <td>{user.username}</td>
                            <td>{user.email}</td>
                            <td>{user.created}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Users.renderUsersTable(this.state.users);

        return (
            <div>
                <h1>Users</h1>
                <p>This is a list of the users.</p>
                {contents}
            </div>
        );
    }
}
