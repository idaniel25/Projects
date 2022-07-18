import "./Form.css";
import { useState } from "react";
import Hotels from "../data/hotels.json";
import Modal from "./Modal";

const Form = () => {
  const [values, setValues] = useState({
    name: "",
    date: "",
    nrNights: 10,
    nrGuests: 2,
    bfIncluded: false,
    hotel: "",
  });
  const [errors, setErrors] = useState({});
  const [openModal, setOpenModal] = useState(false);

  const handleNameChange = (e) => {
    setValues({ ...values, name: e.target.value });
    setErrors({ ...errors, name: false });
  };

  const handleNrGuestsChange = (e) => {
    setValues({ ...values, nrGuests: e.target.value });
    setErrors({ ...errors, nrGuests: false });
  };

  const handleDateChange = (e) => {
    setValues({ ...values, date: e.target.value });
    setErrors({ ...errors, date: false });
  };

  const handleNrNightsChange = (e) => {
    setValues({ ...values, nrNights: e.target.value });
  };

  const handleBfIncludedChange = (e) => {
    setValues({ ...values, bfIncluded: e.target.checked });
  };

  const handleHotelChange = (e) => {
    setValues({ ...values, hotel: e.target.value });
    setErrors({ ...errors, hotel: false });
  };

  const closeModal = () => {
    setOpenModal(false);
    window.location.reload();
    window.scrollTo(0, 0);
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    let errors = {};

    if (!values.name || values.name.length < 3) {
      errors.name = true;
    }

    if (values.nrGuests > 3) {
      errors.nrGuests = true;
    }

    if (!values.date) {
      errors.date = true;
    }

    let ok = 0;

    for (var i = 0; i < Hotels.length; i++) {
      if (Hotels[i].name === values.hotel) ok++;
    }

    if (ok === 0) {
      errors.hotel = true;
    }

    if (errors.name || errors.nrGuests || errors.date || errors.hotel) {
      alert("Form is not valid. Please correct the errors and try again.");
    }

    if (!errors.name && !errors.nrGuests && !errors.date && !errors.hotel) {
      setOpenModal(true);
      disableScroll();
    }

    setErrors(errors);
  };

  const disablePastDate = () => {
    var dtToday = new Date();
    var month = dtToday.getMonth() + 1;
    var day = dtToday.getDate();
    var year = dtToday.getFullYear();
    if (month < 10) month = "0" + month.toString();
    if (day < 10) day = "0" + day.toString();
    var maxDate = year + "-" + month + "-" + day;
    return maxDate;
  };

  const disableScroll = () => {
    document.body.classList.add("stop-scrolling");
  };

  const enableScroll = () => {
    document.body.classList.remove("stop-scrolling");
  };

  return (
    <>
      <form
        onSubmit={handleSubmit}
        className="margin-top-2rem margin-bottom-2rem max-width-500 margin-auto flex flex-direction-column"
      >
        <input
          className={
            errors.name
              ? "red-border-2px input margin-top-20"
              : "margin-top-20 input border-transparent"
          }
          type="text"
          placeholder="Your name..."
          name="name"
          id="name"
          value={values.name}
          onChange={handleNameChange}
        />

        <label
          htmlFor="hotel"
          className="width-305 margin-top-10-left-and-right-auto text-left"
        >
          Please select your preferred hotel
        </label>

        <select
          value={values.hotel}
          onChange={handleHotelChange}
          name="hotel"
          id="hotel"
          className={
            errors.hotel
              ? "red-border-2px input margin-top-2px"
              : "input border-transparent margin-top-2px"
          }
        >
          <option value="" disabled hidden>
            --Please select a hotel--
          </option>
          {Hotels.map((hotel) => (
            <option key={hotel.id} value={hotel.name}>
              {hotel.name}
            </option>
          ))}
        </select>

        <label
          htmlFor="date"
          className="width-305 margin-top-10-left-and-right-auto text-left"
        >
          Please select the date{" "}
        </label>

        <input
          type="date"
          min={disablePastDate()}
          name="date"
          id="date"
          value={values.date}
          onChange={handleDateChange}
          className={
            errors.date
              ? "red-border-2px input margin-top-2px"
              : "input border-transparent margin-top-2px"
          }
        />

        <label
          htmlFor="nrNights"
          className="width-305 margin-top-10-left-and-right-auto text-left"
        >
          Please select the number of nights
        </label>

        <select
          required
          value={values.nrNights}
          onChange={handleNrNightsChange}
          className="input border-transparent margin-top-2px"
          name="nrNights"
          id="nrNights"
        >
          <option>3</option>
          <option>7</option>
          <option>10</option>
          <option>14</option>
          <option>30</option>
        </select>

        <label
          htmlFor="nrGuests"
          className="width-305 margin-top-10-left-and-right-auto text-left"
        >
          Please select the number of guests
        </label>

        <input
          type="number"
          className={
            errors.nrGuests
              ? "red-border-2px input margin-top-2px"
              : "input border-transparent margin-top-2px"
          }
          name="nrGuests"
          id="nrGuests"
          min={1}
          value={values.nrGuests}
          onChange={handleNrGuestsChange}
        />

        <div className="width-305 margin-top-10-left-and-right-auto text-left flex items-center">
          <label htmlFor="breakfast">Do you want breakfast?</label>
          <input
            type="checkbox"
            value={values.bfIncluded}
            onChange={handleBfIncludedChange}
            name="breakfast"
            id="breakfast"
          />
        </div>
        <div className="paper">
          <div className="paper-content">
            <span>The reservation confirmation </span>
            <p>Guest name: {values.name}'s booking</p>
            <p>
              {values.nrGuests <= 1
                ? "Number of guests: " + values.nrGuests + " Guest visiting"
                : "Number of guests: " + values.nrGuests + " Guests visiting"}
            </p>
            <p>Check-in date: {values.date}</p>
            <p>Staying for {values.nrNights} nights</p>
            <p> {values.bfIncluded && "Breakfast included"}</p>
            {values.bfIncluded
              ? Hotels.map((h) => {
                  if (h.name === values.hotel)
                    return (
                      <p key={h.id} className="font-weight-700">
                        Total price: $
                        {(h.price_ppn + h.breakfast_price) *
                          values.nrNights *
                          values.nrGuests}
                      </p>
                    );
                })
              : Hotels.map((h) => {
                  if (h.name === values.hotel)
                    return (
                      <p key={h.id}>
                        Total price: $
                        {h.price_ppn * values.nrNights * values.nrGuests}
                      </p>
                    );
                })}
          </div>
        </div>
        <div className="padding-bottom-20 margin-top-20">
          <button className="btn" type="submit">
            SUBMIT
          </button>
        </div>
      </form>
      {openModal &&
        Hotels.map((hotel) => {
          if (hotel.name === values.hotel)
            return (
              <div key={hotel.id}>
                <Modal
                  featured_image={hotel.featured_image}
                  alt={hotel.alt}
                  booking_message={hotel.booking_message}
                  closeModal={closeModal}
                />
              </div>
            );
        })}
      {!openModal && enableScroll()}
    </>
  );
};

export default Form;
