import React from 'react'
import './Card.css'

interface Props {
    companyName: string;
    price: number;
    ticker: string;
}

const Card: React.FC<Props> = ({companyName, price, ticker}) => {
    return (
        <div className="card">
            <img
                src="https://images.unsplash.com/photo-1726458573518-04a433641cb4" alt="things"/>
            <div className="details">
                <h2>
                    {companyName} ({ticker})
                </h2>
                <p>${price}</p>
            </div>
            <div className="info">
                <p>Lorem Ipsum. </p>
            </div>
        </div>
    )
};

export default Card;