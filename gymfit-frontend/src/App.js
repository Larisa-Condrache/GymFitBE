import React, { useState } from 'react';
import Login from './Login';
import Register from './Register';
import 'bootstrap/dist/css/bootstrap.min.css';

function App() {
  const [view, setView] = useState('login');
  const [role, setRole] = useState(null);

  const handleLogin = (userRole) => {
    setRole(userRole);
  };

  const handleRegister = (userRole) => {
    setRole(userRole);
    setView('login');
  };

  return (
    <div>
      {!role ? (
        <>
          {view === 'login' ? (
            <>
              <Login onLogin={handleLogin} />
              <p className="text-center mt-3">
                Don't have an account?{' '}
                <button
                  className="btn btn-link"
                  onClick={() => setView('register')}
                >
                  Register here
                </button>
              </p>
            </>
          ) : (
            <Register onRegistered={handleRegister} />
          )}
        </>
      ) : (
        <div className="container mt-5">
          <h1>Welcome, {role === 'trainer' ? 'Trainer' : 'Client'}!</h1>
          <p>This is your dashboard.</p>
        </div>
      )}
    </div>
  );
}

export default App;
