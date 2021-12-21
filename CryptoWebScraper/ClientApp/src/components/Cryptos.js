import React, { Component } from 'react';
import { withRouter, Link } from 'react-router-dom';
const axios = require('axios');

class Cryptos extends Component {

    constructor(props) {
		super(props);
		this.state = {
            loading: true,
            cryptocurrencies: [],
        };
	}

    componentDidMount() {
		this.populateCryptosData();
	}

    async populateCryptosData() {
        const url = 'https://localhost:44458/WebScraper/cryptocurrencies';
        axios.get(url, {
            responseType: 'application/json',
        })
        .then((response) => {
            this.setState({ cryptocurrencies: response.data, loading: false });
        }).catch((error) => {});
	}

    render() {
        return (
			<div>
				<h1>CryptoCurrencies</h1>
                <br/>

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
                            {this.state.cryptocurrencies.map((crypto) => (
                                <tr key={crypto.index}>
                                    <td>{crypto.rank}</td>
                                    <td>{crypto.symbol}</td>
                                    <td>
                                        <Link to={`/cryptos/${crypto.currencyName}`}>
                                            {crypto.currencyName}
                                        </Link>
                                    </td>
                                    <td>{crypto.price}</td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                }
                <br/>
			</div>
        );
    }
}

export default withRouter(Cryptos);
