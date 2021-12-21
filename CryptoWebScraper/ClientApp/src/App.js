import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';

import './custom.css';
import SearchCrypto from './components/SearchCrypto';
import Cryptos from './components/Cryptos';
import CryptoInfo from './components/CryptoInfo';

export default class App extends Component {
	static displayName = App.name;

	render() {
		return (
			<Layout>
				<Route exact path="/" component={Home} />
				<Route path="/cryptos" exact component={Cryptos} />
				<Route path="/cryptos/:id" component={CryptoInfo} />
                <Route path="/crypto-chart" component={SearchCrypto} />
			</Layout>
		);
	}
}
