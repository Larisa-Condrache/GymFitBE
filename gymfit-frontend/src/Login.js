import React, { useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import { api } from './api';

function Login({ onLogin }) {
    const [role, setRole] = useState('client');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const handleSubmit = async (e) => {
        e.preventDefault();

        const userData = {
            role: role === 'trainer' ? 1 : 0,
            email,
            password,
        };

        try {
            console.log("Sending this to API:", userData);
            const response = await api.post('/Clients/login', userData);
            alert(`✅ Welcome back, ${response.data.firstName}!`);
            onLogin && onLogin(role);
        } catch (error) {
            console.error('Login error:', error.response?.data || error.message);
            alert('❌ Login failed: Incorrect email or password.');
        }
    };

  return (
    <div className="container mt-5" style={{ maxWidth: 400 }}>
      <h2 className="text-center mb-4">Gym Login</h2>
      <form onSubmit={handleSubmit}>
        <div className="mb-3">
          <label className="form-label">Role</label>
          <select
            className="form-select"
            value={role}
            onChange={(e) => setRole(e.target.value)}
          >
            <option value="client">Client</option>
            <option value="trainer">Trainer</option>
          </select>
        </div>
        <div className="mb-3">
          <label className="form-label">Email</label>
          <input
            type="email"
            className="form-control"
            required
            value={email}
            onChange={(e) => setEmail(e.target.value)}
          />
        </div>
        <div className="mb-3">
          <label className="form-label">Password</label>
          <input
            type="password"
            className="form-control"
            required
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
        </div>
        <button type="submit" className="btn btn-primary w-100">
          Login
        </button>
      </form>
    </div>
  );
}

export default Login;
