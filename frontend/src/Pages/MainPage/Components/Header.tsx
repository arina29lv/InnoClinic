import React from "react";
import Button from "@mui/material/Button";
import "../css/Header.css";

const Header: React.FC = () => {
  return (
    <header className="header">
      <h1 className="logo">InnoClinic</h1>

      {/* Navigation */}
      <nav className="nav-links">
        <a href="#about">About</a>
        <a href="#services">Services</a>
        <a href="#contacts">Contacts</a>
      </nav>

      <div className="header-buttons">
        <Button variant="outlined" color="primary">Login</Button>
        <Button variant="contained" color="primary">Sign Up</Button>
      </div>
    </header>
  );
};

export default Header;
