import React, { useState, useEffect } from 'react';

const ResumeList = () => {
  const [resumes, setResumes] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState('');

  useEffect(() => {
    const fetchResumes = async () => {
      try {
        setIsLoading(true);
        setError('');
        const response = await fetch('/api/resumes');
        if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
        }
        const data = await response.json();
        setResumes(data);
      } catch (err) {
        setError(err.message);
      } finally {
        setIsLoading(false);
      }
    };

    fetchResumes();
  }, []);

  if (isLoading) {
    return <p>Loading resumes...</p>;
  }

  if (error) {
    return <p>Error: {error}</p>;
  }

  return (
    <div>
      <h2>Resumes</h2>
      <ul>
        {resumes.map((resume) => (
          <li key={resume.id}>
            Resume ID: {resume.id} - Name: {resume.personalInfo?.fullName}
          </li>
        ))}
      </ul>
    </div>
  );
};

export default ResumeList;
