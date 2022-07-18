import React from "react";
import Logo from "../assets/Logo.png";
import "./Header.css";

const Header = () => {
  return (
    <header className="border-bottom-black-2px white-background padding-half-a-rem">
      <div className="max-width-1200 flex content-between margin-auto items-center">
        <img className="width-75" src={Logo} alt="Hotel Logo" />
        <nav>
          <ul className="flex gap-30">
            <li><a className="no-decorations color-default underline font-weight-700 font-size-17" href="#Our-Hotels">Our Hotels</a></li>
            <li><a className="no-decorations color-default underline font-weight-700 font-size-17" href="#Why-Book-With-Us">Why Book With Us</a></li>
            <li><a className="no-decorations color-default underline font-weight-700 font-size-17" href="#Book-Now">Book Now</a></li>
          </ul>
        </nav>
      </div>
    </header>
  );
};

export default Header;
