import Hotels from "../data/hotels.json";
import HotelCard from "./HotelCard";

const HotelsCardsList = () => {
  return (
    <>
      {Hotels.map((hotel) => {
        return (
          <div key={hotel.id}>
            <HotelCard
              featured_image={hotel.featured_image}
              alt={hotel.alt}
              name={hotel.name}
              price_ppn={hotel.price_ppn}
              breakfast_price={hotel.breakfast_price}
              star_rating={hotel.star_rating}
            />
          </div>
        );
      })}
    </>
  );
};

export default HotelsCardsList;
