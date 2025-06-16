import React, { useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import { api } from './api'; // uses axios to send POST

function Register({ onRegistered }) {
  const [role, setRole] = useState('client');
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [email, setEmail] = useState('');
  const [phoneNumber, setPhoneNumber] = useState('');
  const [password, setPassword] = useState(''); // Added password state

  const handleSubmit = async (e) => {
    e.preventDefault();

    const userData = {
    role: role === 'trainer' ? 1 : 0,
    firstName,
    lastName,
    email,
    password,
    phoneNumber,
    };

    try {
        console.log("Sending this to API:", userData); // ✅ log before sending
        await api.post('/Clients', userData);
        alert('✅ Registered successfully!');
        onRegistered && onRegistered(role);
    } catch (error) {
        console.error('Registration error:', error.response?.data || error.message);
        alert('❌ Registration failed.');
    }

  };

  return (
    <div className="container mt-5" style={{ maxWidth: 500 }}>
      <h2 className="text-center mb-4">Register</h2>
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
          <label className="form-label">First Name</label>
          <input
            className="form-control"
            value={firstName}
            onChange={(e) => setFirstName(e.target.value)}
            required
          />
        </div>
        <div className="mb-3">
          <label className="form-label">Last Name</label>
          <input
            className="form-control"
            value={lastName}
            onChange={(e) => setLastName(e.target.value)}
            required
          />
        </div>
        <div className="mb-3">
          <label className="form-label">Email</label>
          <input
            type="email"
            className="form-control"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
          />
        </div>
        <div>
            <label className="form-label">Password</label>
            <input
                type="password"
                className="form-control"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                required
                />
        </div>
        <div className="mb-3">
          <label className="form-label">Phone Number</label>
          <input
            className="form-control"
            value={phoneNumber}
            onChange={(e) => setPhoneNumber(e.target.value)}
            required
          />
        </div>
        <button type="submit" className="btn btn-success w-100">
          Register
        </button>
      </form>
    </div>
  );
}

export default Register;
