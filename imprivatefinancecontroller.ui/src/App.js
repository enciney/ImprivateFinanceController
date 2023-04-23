import './App.css';
import React, { useState, useEffect } from 'react';

export function App() {
  return GetExchanges();
}

function GetExchanges(){
  const [data, setData] = useState(null);

  const requestOptions = {
    method: 'GET',
    headers: { 
      'Content-Type': 'application/json',
      // body: JSON.stringify({ title: 'React POST Request Example' })
    }
  };

    const fetchData = async () =>
    {
      fetch('http://localhost:5059/exchange/exchanges', requestOptions)
      .then(response => response.json())
      .then(data => setData(data))
      .catch(error => console.error(error));
    }
    
    return (
    <div>
      <button onClick={fetchData}>Exchange Values</button>
      {data && <Results data={data} />}
    </div>
    );


}

function Results({ data }) {
  return (
    <div>
      {data ? (
        <ul>
          {data.map(item => (
            <div key={item.amount}>
              <span>{item.targetCurrencyName} {item.sourceCurrenyName} {item.amount}</span>
            </div>
          ))}
        </ul>
      ) : (
        <p>No results found.</p>
      )}
    </div>
  );
}

export default App;
