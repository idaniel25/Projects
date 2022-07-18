import React from "react";
import "./Modal.css";
import { IonIcon } from "@ionic/react";
import { close } from "ionicons/icons";
import oceanAudio from "../assets/oceanAudio.mp3";

const Modal = (props) => {
  return (
    <div className="modalBackground">
      <div className="modal">
        <img
          className="modal-profile-img"
          src={props.featured_image}
          alt={props.alt}
        />
        <div className="modal-description-background"></div>
        <div className="modal-logo">
          <img
            src="https://cms-assets.tutsplus.com/cdn-cgi/image/width=630/uploads/users/523/posts/31399/image/simple-emoji-example.png"
            alt="Emoji smiley face"
          />
        </div>
        <div className="modal-description">
          <p>{props.booking_message}</p>
        </div>
        <div className="modal-date">
          <p>{`${new Date().getDate()} / ${
            new Date().getMonth() + 1
          } / ${new Date().getFullYear()}`}</p>
        </div>
        <button className="modal-btn" onClick={props.closeModal}>
          <IonIcon icon={close} className="close-icon" />
        </button>
      </div>
      <audio controls autoPlay className="display-none">
        <source src={oceanAudio} type="audio/mpeg" />
      </audio>
    </div>
  );
};

export default Modal;
