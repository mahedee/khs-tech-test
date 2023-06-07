import React, { Component } from "react";
import { EditClient, GetClientById } from "../../services/ClientService";

export default class ClientEdit extends Component {
  constructor(props) {
    super(props);

    this.onChangeFirstName = this.onChangeFirstName.bind(this);
    this.onChangeLastName = this.onChangeLastName.bind(this);
    this.onSubmit = this.onSubmit.bind(this);

    this.state = {
      id: "",
      firstName: "",
      lastName: "",
    };
  }

  componentDidMount() {
    const id = window.location.href.split("/")[4];
    GetClientById(id).then((response) => {
      const client = response.data;
      this.setState({
        id: client.id,
        firstName: client.firstName,
        lastName: client.lastName,
      });
    });
  }

  onChangeFirstName(e) {
    this.setState({
      firstName: e.target.value,
    });
  }

  onChangeLastName(e) {
    this.setState({
      lastName: e.target.value,
    });
  }

  onUpdateCancel() {
    window.location.replace("/client");
  }

  onSubmit(e) {
    e.preventDefault();
    const id = window.location.href.split("/")[4];
    let clientObj = {
      id: this.state.id,
      firstName: this.state.firstName,
      lastName: this.state.lastName,
    };

    EditClient(id, clientObj).then((result) => {
      window.location.replace("/client");
    });
  }

  render() {
    return (
      <div className="row">
        <div className="col-md-4">
          <h3>Edit Client</h3>
          <form onSubmit={this.onSubmit}>
            <div className="form-group">
              <label className="control-label">First Name: </label>
              <input
                className="form-control"
                type="text"
                value={this.state.firstName}
                onChange={this.onChangeFirstName}
              ></input>
            </div>

            <div className="form-group">
              <label className="control-label">Last Name: </label>
              <input
                className="form-control"
                type="text"
                value={this.state.lastName}
                onChange={this.onChangeLastName}
              ></input>
            </div>
            <div className="form-group">
              <br></br>
            </div>

            <div className="form-group">
              <button onClick={this.onUpdateCancel} className="btn btn-default">
                Cancel
              </button>
              <input
                type="submit"
                value="Edit"
                className="btn btn-primary"
              ></input>
            </div>
          </form>
        </div>
      </div>
    );
  }
}
