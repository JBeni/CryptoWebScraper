import React, { Component } from 'react';
const axios = require('axios');

export default class SearchCrypto extends Component {

    constructor(props) {
		super(props);
		this.state = {
            cryptoName: '',
            loading: true,
            historicalData: [],
            cryptocurrency: [],
        };
	}

    componentDidMount() {}

    handleChange = (event) => {
        this.setState({ cryptoName: event.target.value });
    };

    async getCryptocurrencyData() {
        const url = `https://localhost:44458/WebScraper/`;
        axios.get(url + `cryptocurrency/${this.state.cryptoName}`, {
            responseType: 'application/json',
        })
        .then((response) => {
            this.setState({ cryptocurrency: response.data, loading: false });
        }).catch((error) => {});

        axios.get(url + `cryptocurrencyHistoricalData/${this.state.cryptoName}`, {
            responseType: 'application/json',
        })
        .then((response) => {
            this.setState({ historicalData: response.data });
        }).catch((error) => {});
	}

    render() {
        return (
			<div>
				<h1>Cryptocurrency</h1>
                <br/>

                <input
                    type="text"
                    placeholder="Cryptocurrency Name"
                    value={this.state.cryptoName}
                    onChange={this.handleChange}
                />
                <span> | </span>
                <button
                    variant="contained"
                    size="large"
                    color="primary"
                    type="submit"
                    onClick={() => { this.getCryptocurrencyData(); }}
                >Get Crypto</button>
                <br/><br/>

                {
                    this.state.loading ?
                        <p><em>Loading...</em></p>
                    : <table className="table table-striped" aria-labelledby="tabelLabel">
                        <thead>
                            <tr>
                                <th>Rank</th>
                                <th>Symbol</th>
                                <th>Currency Name</th>
                                <th>Price</th>
                            </tr>
                        </thead>
                        <tbody>
                            {this.state.cryptocurrency.map((crypto) => (
                                <tr key={crypto.index}>
                                    <td>{crypto.rank}</td>
                                    <td>{crypto.symbol}</td>
                                    <td>{crypto.currencyName}</td>
                                    <td>{crypto.price}</td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                }
			</div>
        );
    }
}
