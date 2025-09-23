import React from "react";
import "./css/MainPage.css";

import Header from "./Components/Header";
import HeroBanner from "./Components/HeroBanner";
import AboutSection from "./Components/AboutSection";
import PopularServices from "./Components/PopularServices";
import ConsultationButton from "./Components/ConsultationButton";
import Footer from "./Components/Footer";

import photo from "../../assets/MenuBanner.avif";

const MainPage: React.FC = () => {
  return (
    <div className="main-page">
      <Header />
      <HeroBanner
        imageSrc={photo}
        title="Your path to top Healthcare"
        subtitle="We connect you with the right specialist for your case"
      />

      {/* About section */}
      <section id="about" className="page-section">
        <AboutSection />
      </section>

      {/* Services section */}
      <section id="services" className="page-section">
        <PopularServices />
      </section>

      <ConsultationButton />

      {/* Contacts (footer) */}
      <footer id="contacts" className="page-section">
        <Footer />
      </footer>
    </div>
  );
};

export default MainPage;
