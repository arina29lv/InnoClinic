import React from "react";
import "../css/AboutSection.css";
import FeatureCard from "./FeatureCard";

// MUI icons
import {
  WorkspacePremium,
  Security,
  LocalHospital,
  Biotech,
} from "@mui/icons-material";

const AboutSection: React.FC = () => (
    <section className="section-container about-section">
        {/* LEFT: TEXT */}
        <div className="about-left">
            <h3 className="about-title">WELCOME to InnoClinic</h3>

            <p className="about-lead">
                A premium private clinic where the expertise of our
                doctors and advanced technology work together for your health.
            </p>

            <p className="about-lead">
                We provide comprehensive care ranging from the treatment of complex
                medical conditions to personalized recovery and wellness programs.
                Our clinic offers not only cutting-edge therapies but also an
                environment of comfort and privacy, including accommodation for
                patients who require longer stays.
            </p>

            <blockquote className="about-quote">
                At InnoClinic, every detail is designed to deliver a world-class
                healthcare experience — from attentive medical supervision and
                evidence-based protocols to premium hospitality.
            </blockquote>

        </div>

        {/* RIGHT: FEATURES */}
        <div className="about-right">
            <FeatureCard
                icon={<WorkspacePremium fontSize="inherit" />}
                title="Top specialists"
                text="Licensed and highly experienced doctors with international practice and proven expertise." />
            <FeatureCard
                icon={<Biotech fontSize="inherit" />}
                title="Modern equipment"
                text="Cutting-edge equipment ensuring accurate diagnostics and effective treatment." />
            <FeatureCard
                icon={<Security fontSize="inherit" />}
                title="Premium service"
                text="Discreet privacy with 24/7 support, personalized care, and premium accommodations." />
            <FeatureCard
                icon={<LocalHospital fontSize="inherit" />}
                title="Comprehensive care"
                text="From complex conditions to recovery and long-term care — all provided under one roof." />
        </div>
    </section>
);

export default AboutSection;
