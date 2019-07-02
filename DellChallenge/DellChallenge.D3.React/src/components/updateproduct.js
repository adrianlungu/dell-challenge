import React, {Component} from "react";
import {Redirect} from "react-router-dom";
import Validation from "../validation";

class UpdateProduct extends Component {
    constructor() {
        super();
        this.state = {
            Id: '',
            Name: '',
            Category: '',
            Success: false,
            Error: '',
        };
        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    componentDidMount() {
        const item = this.props.location.state;

        this.setState({
            Id: item.id,
            Name: item.name,
            Category: item.category,
        })
    }

    handleSubmit = event => {
        event.preventDefault();

        if (this.state.Name.length < 3) {
            this.setState({
                Error: "Name is too small. Must be minimum 3 characters.",
            });
            return;
        }

        this.setState({
            Error: "",
        });

        let postData = {
            Id: this.state.Id,
            Name: this.state.Name,
            Category: this.state.Category
        };

        fetch("http://localhost:5000/api/products", {
            method: "PUT",
            headers: {
                Accept: "application/json",
                "Content-Type": "application/json"
            },
            mode: "cors",
            body: JSON.stringify(postData)
        })
            .then(this.props.history.push('/products'))
            .catch(err => console.log(err));
    };

    handleInputChange = event => {
        const target = event.target;
        const value = target.type === "checkbox" ? target.checked : target.value;
        const name = target.name;

        this.setState({
            [name]: value
        });
    };

    render() {
        return (
            <form onSubmit={this.handleSubmit}>
                <h4>Update Product Id {this.state.Id}</h4>
                <div className="form-group">
                    <label className="control-label" htmlFor="Name">
                        Name
                    </label>
                    <input
                        className="form-control"
                        type="text"
                        id="Name"
                        name="Name"
                        onChange={this.handleInputChange}
                        value={this.state.Name}
                    />
                    <span
                        className="text-danger field-validation-valid"
                        data-valmsg-for="Name"
                        data-valmsg-replace="true">
                        { this.state.Error }
                    </span>
                </div>
                <div className="form-group">
                    <label className="control-label" htmlFor="Category">
                        Category
                    </label>
                    <input
                        className="form-control"
                        type="text"
                        id="Category"
                        name="Category"
                        onChange={this.handleInputChange}
                        value={this.state.Category}
                    />
                    <span
                        className="text-danger field-validation-valid"
                        data-valmsg-for="Category"
                        data-valmsg-replace="true"
                    />
                </div>
                <div className="form-group">
                    <button className="btn btn-primary">Submit</button>
                </div>
                <Validation/>
            </form>
        );
    }
}

export default UpdateProduct;
