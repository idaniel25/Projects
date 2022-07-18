import "./App.css";
import Header from "./components/Header";
import OurHotelsSection from "./components/OurHotelsSection";
import WhyBookWithUsSection from "./components/WhyBookWithUsSection";
import BookNowSection from "./components/BookNowSection";
import Footer from "./components/Footer";

function App() {
  return (
    <div className="App">
      <Header />
      <main>
        <OurHotelsSection />
        <WhyBookWithUsSection />
        <BookNowSection />
      </main>
      <Footer />
    </div>
  );
}

export default App;
