import React from 'react';
import { CustomerListData } from './CustomerList';

export class AddCustomer extends React.Component {
    constructor(props) {
        super(props);

        //here we are intializing the interface's fields with default values.
        this.state = { title: "", loading: true, customerList: new CustomerListData };

        //the customerId variable will get the customer id from URL.
        var customerId = this.props.match.params["customerId"];

        //if customerId is greater than 0 then fetch method will get the specific customer record and display it as in edit mode.
        if (customerId > 0) {
            fetch('api/Customer/Details/' + customerId)
                .then(response => response.json())
                .then(data => {
                    this.setState({ title: "Edit", loading: false, customerList: data });
                });
        }
        else {
            this.state = { title: "Create", loading: false, customerList: new CustomerListData };
        }

        this.FuncSave = this.FuncSave.bind(this);
        this.FuncCancel = this.FuncCancel.bind(this);
    }
    //this method will render html onto the DOM.
    render() {
        console.log("hello");
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderCreateForm();
        return <div>
            <h1>{this.state.title}</h1>
            <h3>Customer</h3>
            <hr />
            {contents}
        </div>;
    }



    //this method will save the record into database. If the URL has an CustomerId, 
    //then it will update the record and if the URL has not customer Id parameter than it will save the record.
    FuncSave(event) {
        event.preventDefault();
        const data = new FormData(event.target);
        console.log("print:", data);
        // PUT request for Edit customer.  
        if (this.state.customerList.customerId) {
            fetch('api/Customer/Edit', {
                method: 'PUT',
                body: data,
            }).then((response) => response.json())
                .then((responseJson) => {
                    this.props.history.push("/customer/index");
                })
        }
        else {
            fetch('api/Customer/Create', {
                method: 'POST',
                body: data,
            }).then((response) => response.json())
                .then((responseJson) => {
                    this.props.history.push("/customer/index");
                })
        }
    }


    FuncCancel(e) {
        e.preventDefault();
        this.props.history.push("/customer/index");
    }

    //this method will return the html table to display all the customer record with edit and delete methods.
    renderCreateForm() {
        return (

            <form onSubmit={this.FuncSave} >
                <div className="form-group row" >
                    <input type="hidden" name="CustomerId" value={this.state.customerList.customerId} />
                </div>
                < div className="form-group row" >
                    <label className=" control-label col-md-12" htmlFor="name">Name</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="customerName" defaultValue={this.state.customerList.customerName} required />
                    </div>
                </div >

                <div className="form-group row">
                    <label className="control-label col-md-12" htmlFor="address" >Address</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="customerAddress" defaultValue={this.state.customerList.customerAddress} required />
                    </div>
                </div>


                <div className="form-group">
                    <button type="submit" style={{ backgroundColor: "yellow" }} className="btn btn-default">Save</button>
                    {' '}
                    <button className="btn" style={{ backgroundColor: "yellow" }} onClick={this.FuncCancel}>Cancel</button>
                </div >
            </form >
        )
    }
}