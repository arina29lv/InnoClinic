import React from "react";
import Button from "@mui/material/Button";
import "../css/HeroBanner.css";

type HeroBannerProps = {
  imageSrc: string;
  title: string;
  subtitle: string;
};

const HeroBanner: React.FC<HeroBannerProps> = ({ imageSrc, title, subtitle }) => {
  return (
    <section className="image-section">
      <img src={imageSrc} alt="Clinic" className="clinic-photo" />

      <div className="section-container banner-text">
        <h2 className="banner-title">{title}</h2>

        <p className="banner-subtitle">{subtitle}</p>

        <Button
          variant="outlined"
          sx={{
            color: "#ad0000",
            borderColor: "#ad0000",
            fontWeight: "400",
            fontSize: "16px",
            textTransform: "none",
            marginTop: "12px", // отступ сверху
            "&:hover": {
              borderColor: "#ad0000",
              backgroundColor: "rgba(139,0,0,0.05)",
            },
          }}
        >
          BOOK A CONSULTATION
        </Button>
      </div>
    </section>
  );
};

export default HeroBanner;
