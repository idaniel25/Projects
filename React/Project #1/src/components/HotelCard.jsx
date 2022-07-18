import "./HotelCard.css";

const HotelCard = (props) => {
  return (
    <div className="card">
      <img src={props.featured_image} className="card__image" alt={props.alt} />
      <div className="card__overlay">
        <div className="card__header">
          <svg className="card__arc" xmlns="http://www.w3.org/2000/svg">
            <path d="M 40 80 c 22 0 40 -22 40 -40 v 40 Z" />
          </svg>
          <div>
            <h2 className="card__title">{props.name}</h2>
          </div>
        </div>
        <div className="card__description">
          <p className="card__pricepn">${props.price_ppn}/night</p>
          <div className="flex flex-direction-column">
            <p>${props.breakfast_price} breakfast</p>
            <p>
              {props.star_rating === 3
                ? "\u2B50 \u2B50 \u2B50"
                : props.star_rating === 4
                ? "\u2B50 \u2B50 \u2B50 \u2B50"
                : "\u2B50 \u2B50 \u2B50 \u2B50 \u2B50"}
            </p>
          </div>
        </div>
      </div>
    </div>
  );
};

export default HotelCard;
