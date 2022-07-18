import "./AdvantageCard.css";

const AdvantageCard = (props) => {
  return (
    <div className="a-box">
      <div className="img-container">
        <div>
          <div className="inner-skew">
            <img src={props.src} alt={props.alt} />
          </div>
        </div>
      </div>
      <div className="text-container">
        <h2>{props.title}</h2>
        <div>
          <p>{props.description}</p>
        </div>
      </div>
    </div>
  );
};

export default AdvantageCard;
