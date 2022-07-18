import AdvantagesCardsList from "./AdvantagesCardsList"
import './WhyBookWithUsSection.css'

const WhyBookWithUsSection = () => {
    return (
        <section className="margin-auto margin-bottom-8rem max-width-1200">
            <h1 id="Why-Book-With-Us" className="font-size-3em font-weight-700 margin-top-3rem margin-bottom-3rem">Why book with us?</h1>
            <div className="flex content-between"><AdvantagesCardsList /></div>
        </section>
    )
}

export default WhyBookWithUsSection