import "./Footer.css";

const Footer = () => {
  return (
    <footer className="black-background padding-top-bottom-half-a-rem padding-left-right-2rem text-center">
      <p className="font-color-white margin-top-1em margin-bottom-1em">
        All rights reserved © {new Date().getFullYear()}
      </p>
    </footer>
  );
};

export default Footer;
