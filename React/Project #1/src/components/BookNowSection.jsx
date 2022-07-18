import "./BookNowSection.css";
import Form from "./Form";

const BookNowSection = () => {
  return (
    <section className="max-width-960 margin-auto">
      <h2
        id="Book-Now"
        className="font-size-3em font-weight-700 margin-top-3rem margin-bottom-3rem"
      >
        Book Now
      </h2>
      <div>
        <Form />
      </div>
    </section>
  );
};

export default BookNowSection;
