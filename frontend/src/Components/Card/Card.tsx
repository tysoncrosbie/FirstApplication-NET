import React, {SyntheticEvent} from 'react'
import './Card.css'
import {CompanySearch} from "../../company";
import AddPortfolio from '../Portfolio/AddPortfolio/AddPortfolio'

interface Props {
    id: string;
    searchResult: CompanySearch;
    onPortfolioCreate: (e: SyntheticEvent) => void;
}

const Card: React.FC<Props> = ({id, searchResult, onPortfolioCreate}) => {
    return (
        <div className="card">
            <img alt="company logo"/>
            <div className="details">
                <h2>
                    {searchResult.name} {searchResult.symbol}
                </h2>
                <p>${searchResult.currency}</p>
            </div>
            <div className="info">
                <p>{searchResult.exchangeShortName} - {searchResult.stockExchange}</p>
                <AddPortfolio
                    onPortfolioCreate={onPortfolioCreate}
                    symbol={searchResult.symbol}/>
            </div>
        </div>
    )
};

export default Card;