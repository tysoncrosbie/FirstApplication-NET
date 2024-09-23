import Card from "../Card/Card";
import React from "react";

interface Props {
}

const CardList: React.FC<Props> = () => {
    return (
        <div>
            <Card companyName="Apple" ticker="AAPL" price={100}/>
            <Card companyName="Apple" ticker="AAPL" price={100}/>
            <Card companyName="Apple" ticker="AAPL" price={100}/>
        </div>
    )
};
export default CardList;