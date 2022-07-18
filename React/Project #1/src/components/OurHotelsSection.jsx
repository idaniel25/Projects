import HotelsCardsList from "./HotelsCardsList";
import "./OurHotelsSection.css";
const OurHotelsSection = () => {
  return (
    <section className="max-width-960 margin-auto margin-bottom-8rem">
      <h1
        id="Our-Hotels"
        className="margin-top-3rem margin-bottom-3rem font-size-3em font-weight-700"
      >
        Our Hotels
      </h1>
      <div className="flex flex-wrap gap-30">
        <HotelsCardsList />
      </div>
    </section>
  );
};

export default OurHotelsSection;
