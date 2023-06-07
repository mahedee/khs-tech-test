import React, { Component } from "react";
import { GetAllClient } from "../../services/ClientService";
import { Link } from "react-router-dom";

export default class Client extends Component {
  constructor(props) {
    super(props);

    this.OnClientEdit = this.OnClientEdit.bind(this);
    this.OnClientDelete = this.OnClientDelete.bind(this);
    this.onClientCreate = this.onClientCreate.bind(this);

    this.state = {
      clients: [],
      loading: true,
      failed: false,
      error: "",
    };
  }

  componentDidMount() {
    this.populateClientData();
    GetAllClient().then((response) => {});
  }

  // Event handler for create button
  onClientCreate = () => {
    const { history } = this.props;
    history.push("/client-create");
  };

  // Event handler for edit button
  OnClientEdit(id) {
    window.location.replace("/client-edit/" + id);
  }

  // Event handler for delete button
  OnClientDelete(id) {
    window.location.replace("/client-delete/" + id);
  }

  populateClientData() {
    GetAllClient()
      .then((result) => {
        const response = result.data;
        this.setState({ clients: response, loading: false, error: "" });
      })
      .catch((error) => {
        this.setState({
          clients: [],
          loading: false,
          failed: true,
          error: "Clients could not be loaded!",
        });
      });
  }

  renderAllClientTable(clients) {
    return (
      <table className="table table-striped">
        <thead>
          <tr>
            <th>Id</th>
            <th>First Name</th>
            <th>Last Name</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {clients.map((client) => (
            <tr key={client.id}>
              <td>{client.id}</td>
              <td>{client.firstName}</td>
              <td>{client.lastName}</td>
              <td>
                <Link
                  to={"/client-edit/" + client.id}
                  className="btn btn-success"
                >
                  <i className="fa fa-edit"></i> Edit
                </Link>{" "}
                ||
                <button
                  onClick={() => this.OnClientDelete(client.id)}
                  className="btn btn-danger"
                >
                  Delete
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    );
  }

  render() {
    let content = this.state.loading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      this.renderAllClientTable(this.state.clients)
    );

    return (
      <div>
        <h2>Clients</h2>

        <Link to={"/client-create"} className="btn btn-primary">
          Create
        </Link>
        {content}
      </div>
    );
  }
}
