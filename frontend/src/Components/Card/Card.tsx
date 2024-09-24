import React from 'react'
import './Card.css'
import {CompanySearch} from "../../company";

interface Props {
    id: string;
    searchResult: CompanySearch;
}

const Card: React.FC<Props> = ({id, searchResult}) => {
    return (
        <div className="card">
            <img alt="company logo"/>
            <div className="card">
                <h2>
                    {searchResult.name} ({searchResult.symbol})
                </h2>
                <p>${searchResult.currency}</p>
            </div>
            <div className="info">
                <p>{searchResult.exchangeShortName} </p>
            </div>
        </div>
    )
};

export default Card;