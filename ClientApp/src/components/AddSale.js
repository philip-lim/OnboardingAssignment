import React from 'react';
import { SalesListData } from './SalesList';


export class AddSale extends React.Component {
    constructor(props) {
        super(props);
        //here we are intializing the interface's fields with default values.
        this.state = { title: "", loading: true, salesList: new SalesListData() };
        //the salesId variable will get the sales id from URL.
        var salesId = this.props.match.params["salesId"];
        //if salesId is greater than 0 then fetch method will get the specific sales record and display it as in edit mode.
        if (salesId > 0) {
            fetch('api/Sales/Details/' + salesId)
                .then(response => response.json())
                .then(data => {
                    this.setState({ title: "Edit", loading: false, salesList: data });
                });
        }
        else {
            this.state = { title: "Create", loading: false, salesList: new SalesListData() };
        }
        this.FuncSave = this.FuncSave.bind(this);
        this.FuncCancel = this.FuncCancel.bind(this);
    }
    //this method will render html onto the DOM.
    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderCreateForm();
        return <div>
            <h1>{this.state.title}</h1>
            <h3>Sales</h3>
            <hr />
            {contents}
        </div>;
    }
    //this method will save the record into database. If the URL has an SalesId, 
    //then it will update the record and if the URL has not sales Id parameter than it will save the record.
    FuncSave(event) {
        event.preventDefault();
        const data = new FormData(event.target);
        // PUT request for Edit sales record.  
        if (this.state.salesList.salesId) {
            fetch('api/Sales/Edit', {
                method: 'PUT',
                body: data,
            }).then((response) => response.json())
                .then((responseJson) => {
                    this.props.history.push("/sales/index");
                });
        }
        else {
            fetch('api/Sales/Create', {
                method: 'POST',
                body: data,
            }).then((response) => response.json())
                .then((responseJson) => {
                    this.props.history.push("/sales/index");
                });
        }
    }
    FuncCancel(e) {
        e.preventDefault();
        this.props.history.push("/sales/index");
    }
    //this method will return the html table to display all the sales record with edit and delete methods.
    renderCreateForm() {
        return (
            <form onSubmit={this.FuncSave} >
                <div className="form-group row" >
                    <input type="hidden" name="SalesId" value={this.state.salesList.salesId} />
                </div>
                < div className="form-group row" >
                    <label className=" control-label col-md-12" htmlFor="date">Date Sold</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="dateSold" placeholder="YYYY-MM-DDTHH:MI:SS"defaultValue={this.state.salesList.dateSold} required />
                    </div>
                </div >

                <div className="form-group row">
                    <label className="control-label col-md-12" htmlFor="customerId" >Customer</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="customerId" placeholder="Customer Id" defaultValue={this.state.salesList.customerId} required />
                    </div>
                </div>


                <div className="form-group row">
                    <label className="control-label col-md-12" htmlFor="productId" >Product</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="productId" placeholder="Product Id" defaultValue={this.state.salesList.productId} required />
                    </div>
                </div>
                <div className="form-group row">
                    <label className="control-label col-md-12" htmlFor="storeId" >Store</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="storeId" placeholder="Store Id" defaultValue={this.state.salesList.storeId} required />
                    </div>
                </div>

                <div className="form-group">
                    <button type="submit" className="btn btn-default, ui yellow button">Save</button>
                    {' '}
                    <button className="btn, ui yellow button" onClick={this.FuncCancel}>Cancel</button>
                </div >
            </form >
        )
    }
}