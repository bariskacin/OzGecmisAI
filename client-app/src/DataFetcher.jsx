import React, { useState, useEffect } from 'react';

const DataFetcher = () => {
  const [data, setData] = useState(null);
  const [error, setError] = useState('');

  useEffect(() => {
    const fetchData = async () => {
      try {
      const response = await fetch('/api/resumes');
        if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
        }
        const result = await response.json();
        setData(result);
      } catch (err) {
        setError(err.message);
      }
    };

    fetchData();
  }, []);

  return (
    <div style={{ padding: '20px', fontFamily: 'Arial, sans-serif' }}>
      <h2>Data Fetcher</h2>
      {data ? (
        <pre style={{ background: '#f4f4f4', padding: '15px', borderRadius: '5px', overflow: 'auto' }}>
          {JSON.stringify(data, null, 2)}
        </pre>
      ) : (
        <p>Loading data...</p>
      )}
      {error && <p style={{ color: 'red' }}>Error: {error}</p>}
    </div>
  );
};

export default DataFetcher;
