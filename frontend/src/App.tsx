import React from "react";
import MainPage from "./Pages/MainPage/MainPage";
import { createTheme, ThemeProvider } from "@mui/material/styles";

const theme = createTheme({
  palette: { primary: { main: "#ad0000" } },
  components: {
    MuiButton: {
      styleOverrides: {
        root: {
          "&:focus, &:focus-visible": { outline: "none", boxShadow: "none" },
        },
        outlinedPrimary: {
          "&:focus, &:focus-visible": {
            outline: "none",
            boxShadow: "none",
            borderColor: "#ad0000",
          },
        },
      },
    },
  },
});


const App: React.FC = () => {
  return (
    <ThemeProvider theme={theme}>
      <MainPage />
    </ThemeProvider>
  );
};

export default App;
