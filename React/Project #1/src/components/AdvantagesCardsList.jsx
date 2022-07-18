import AdvantageCard from './AdvantageCard'
import Advantages from '../data/advantages.json'

const AdvantagesCardsList = () => {
    return (
        <>
        {
            Advantages.map(advantage=>{
                return (
                    <div key={advantage.title}>
                        <AdvantageCard src={advantage.src} alt={advantage.alt} title={advantage.title} description={advantage.description} />
                    </div>
                )
            })
        }
        </>
    )
}

export default AdvantagesCardsList