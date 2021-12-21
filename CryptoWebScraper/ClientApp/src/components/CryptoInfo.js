import React, { Component } from 'react';
const axios = require('axios');

export default class CryptoInfo extends Component {

    constructor(props) {
		super(props);
		this.state = {
            loading: true,
            cryptocurrency: [],
        };
	}

    componentDidMount() {
        this.getCryptocurrencyInfo();
	}

    async getCryptocurrencyInfo() {
        const url = `https://localhost:44458/WebScraper/cryptocurrencyInfo/${this.props.match.params.id}`;
        axios.get(url)
        .then((response) => {
            this.setState({ cryptocurrency: response.data, loading: false });
        }).catch((error) => {});
	}

    render() {
        return (
			<div>
				<h1>CryptoCurrency Info</h1>
                <br/>

                {
                    this.state.loading ?
                        <p><em>Loading...</em></p>
                    : <div style={{ whiteSpace: 'pre-wrap' }}>
                        {
                            this.state.cryptocurrency[0].message
                        }
                    </div>
                }
                <br/>
			</div>
        );
    }
}
