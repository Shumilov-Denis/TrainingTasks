using Shapes;
using Shapes.Cutting;
using Shapes.ShapesOfFigure;
using System.Collections.Generic;
using TaskException;
using WorkWithFile.WriteOrReadFile;

namespace Boxes
{
    /// <summary>
    /// Box.
    /// </summary>
    public class Box
    {
        /// <summary>
        /// Figures.
        /// </summary>
        public List<Figure> Figures { get; set; }

        /// <summary>
        /// Create new empty box.
        /// </summary>
        public Box()
        {
            Figures = new List<Figure>();
        }

        /// <summary>
        /// Create new box with figures.
        /// </summary>
        /// <param name="figures"></param>
        public Box(List<Figure> figures)
        {
            if (figures.Count > 20 || CheckReadingFigures(figures))
            {
                throw new OverflowBoxException("The shape could not be read because a condition was violated: the number of shapes exceeded 20, or the shapes are being repeated.");
            }

            this.Figures = figures;
        }

        /// <summary>
        /// Calculation of the amount of areas.
        /// </summary>
        public double SumArea
        {
            get
            {
                double sumArea = 0;

                foreach (var figure in Figures)
                {
                    sumArea += figure.Area;
                }

                return sumArea;
            }
        }

        /// <summary>
        /// Calculation of the amount of perimeters.
        /// </summary>
        public double SumPerimeter
        {
            get
            {
                double sumPerimeter = 0;

                foreach (var figure in Figures)
                {
                    sumPerimeter += figure.Perimeter;
                }

                return sumPerimeter;
            }
        }

        /// <summary>
        /// Number of figure in box.
        /// </summary>
        public int Length => Figures.Count;

        /// <summary>
        /// Check if the added shape is in the box.
        /// </summary>
        /// <param name="figureToChecking">Figure to check.</param>
        /// <returns>Returns true if the given shape is not present in the box. A false if it is there.</returns>
        private bool CheckFigureInBox(Figure figureToChecking)
        {
            bool noFigure = true;

            for (int index = 0; index < Figures.Count && noFigure; index++)
            {
                if (figureToChecking.Equals(Figures[index]))
                {
                    noFigure = false;
                }
            }

            return noFigure;
        }

        /// <summary>
        /// Add new figure in the box.
        /// </summary>
        /// <param name="figure">Figure to add.</param>
        public void AddFigure(Figure figure)
        {
            if (Figures.Count < 20)
            {
                if (CheckFigureInBox(figure))
                {
                    this.Figures.Add(figure);
                }
                else
                {
                    throw new CannotAddFigureInBoxException("Cannot add a shape because it is already in the box.");
                }
            }
            else
            {
                throw new OverflowBoxException("Failed to add shape. The box will overflow when added.");
            }
        }

        /// <summary>
        /// Vie figure by number.
        /// </summary>
        /// <param name="number">Number.</param>
        /// <returns>Information about figure.</returns>
        public string ViewFigureByNumber(int number)
        {
            var information = number <= Figures.Count ? Figures[number - 1].ToString() : "Unable to read the shape at the given number.";

            return information;
        }

        /// <summary>
        /// Extracting a shape by number.
        /// </summary>
        /// <param name="number">Number.</param>
        /// <returns>Extracts a piece by number, while removing it from the box.</returns>
        public Figure ExtractByNumber(int number)
        {
            Figure figure = null;

            if (number <= Figures.Count)
            {
                figure = Figures[number - 1];
                Figures.RemoveAt(number - 1);
            }

            return figure;
        }

        /// <summary>
        /// Replacing a shape by number.
        /// </summary>
        /// <param name="figure">The figure to replace.</param>
        /// <param name="number">The replacement piece number.</param>
        public void ReplacementByNumber(Figure figure, int number)
        {
            if (number <= Figures.Count)
            {
                if (CheckFigureInBox(figure))
                {
                    Figures[number - 1] = figure;
                }
                else
                {
                    throw new CannotAddFigureInBoxException("Cannot add a shape because it is already in the box.");
                }
            }
        }

        /// <summary>
        /// Finding a shape by instance.
        /// </summary>
        /// <param name="figureForSearch">Figure instance.</param>
        /// <returns>Returns the found shape if it was found or zero otherwise.</returns>
        public string FindingShape(Figure figureForSearch)
        {
            string foundFigure = null;

            foreach (var figure in Figures)
            {
                if (figureForSearch.Equals(figure))
                {
                    foundFigure = figure.ToString();
                }
            }

            return foundFigure;
        }

        /// <summary>
        /// Takes all the circles out of the box.
        /// </summary>
        /// <returns>List with circles.</returns>
        public List<Circle> GetAllCircles()
        {
            List<Circle> circles = new List<Circle>();

            for (int index = 0; index < Figures.Count; index++)
            {
                if (Figures[index] is Circle)
                {
                    circles.Add(Figures[index] as Circle);
                    Figures.RemoveAt(index);
                    index--;
                }
            }

            return circles;
        }

        /// <summary>
        /// Takes all film figures out of the box.
        /// </summary>
        /// <returns>List with film figures.</returns>
        public List<Figure> GetAllFilmFigures()
        {
            List<Figure> figures = new List<Figure>();

            for (int index = 0; index < Figures.Count; index++)
            {
                if (CheckMaterial.IsFilmFigure(Figures[index]))
                {
                    figures.Add(Figures[index]);
                    Figures.RemoveAt(index);
                    index--;
                }
            }

            return figures;
        }

        /// <summary>
        /// Takes all plastic figures which hasn't painting out of the box.
        /// </summary>
        /// <returns>List with film figures.</returns>
        public List<Figure> GetAllPlasticFiguresHasNotBeenPainting()
        {
            List<Figure> figures = new List<Figure>();

            for (int index = 0; index < Figures.Count; index++)
            {
                if (CheckMaterial.IsPlasticFigure(Figures[index]) && !Figures[index].HasBeenPainting)
                {
                    figures.Add(Figures[index]);
                    Figures.RemoveAt(index);
                    index--;
                }
            }

            return figures;
        }

        /// <summary>
        /// Method for create new list with figure.
        /// </summary>
        /// <param name="material">Material of figure.</param>
        /// <returns>New list with figure.</returns>
        private List<Figure> CreateArrayPerMaterial(SelectionOfShapes material)
        {
            List<Figure> newList = new List<Figure>();

            switch (material)
            {
                case SelectionOfShapes.All: newList = Figures; Figures.RemoveRange(0, Figures.Count); break;
                case SelectionOfShapes.Film: newList = Figures.FoundFigure(CheckMaterial.IsFilmFigure); break;
                case SelectionOfShapes.Paper: newList = Figures.FoundFigure(CheckMaterial.IsPaperFigure); break;
                case SelectionOfShapes.Plastic: newList = Figures.FoundFigure(CheckMaterial.IsPaperFigure); break;
            }

            return newList;
        }

        /// <summary>
        /// Save information in file with use XmlWriter.
        /// </summary>
        /// <param name="wayToFile">Way to file.</param>
        /// <param name="material">Material for save. You can choose: All, Film, Paper, Plastic</param>
        public void SaveFigureInFileWithStear(string wayToFile, SelectionOfShapes material)
        {
            FileWorkWithStream file = new FileWorkWithStream(wayToFile);
            List<Figure> newList = CreateArrayPerMaterial(material);

            if (newList != null)
            {
                file.Save(newList);
            }
        }

        /// <summary>
        /// Save information in file with use XmlWriter.
        /// </summary>
        /// <param name="wayToFile">Way to file.</param>
        /// <param name="material">Material for save. You can choose: All, Film, Paper, Plastic</param>
        public void SaveFigureInFileWithXml(string wayToFile, SelectionOfShapes material)
        {
            FileWorkWithXml file = new FileWorkWithXml(wayToFile);
            List<Figure> newList = CreateArrayPerMaterial(material);

            if (newList != null)
            {
                file.Save(newList);
            }
        }

        /// <summary>
        /// Checking information which was reading from XMLFile.
        /// </summary>
        /// <param name="figures">List with figure for checking</param>
        /// <returns>False if the shapes in the list satisfy the conditions</returns>
        private bool CheckReadingFigures(List<Figure> figures)
        {
            bool figureWas = false;

            for (int indexFirst = 0; indexFirst < figures.Count - 1; indexFirst++)
            {
                for (int indexSecond = indexFirst + 1; indexSecond < figures.Count; indexSecond++)
                {
                    if (figures[indexFirst].Equals(figures[indexSecond]))
                    {
                        figureWas = true;
                    }
                }
            }

            return figureWas;
        }

        /// <summary>
        /// Read file from XML file.
        /// </summary>
        /// <param name="wayToFile">Way to file.</param>
        public void ReadFromFileWithStream(string wayToFile)
        {
            FileWorkWithStream file = new FileWorkWithStream(wayToFile);
            List<Figure> figures = file.Read();

            if (figures.Count > 20 || CheckReadingFigures(figures))
            {
                throw new OverflowBoxException("The shape could not be read because a condition was violated: the number of shapes exceeded 20, or the shapes are being repeated.");
            }

            this.Figures = figures;
        }

        /// <summary>
        /// Read file from XML file.
        /// </summary>
        /// <param name="wayToFile">Way to file.</param>
        public void ReadFromFileWithXml(string wayToFile)
        {
            FileWorkWithXml file = new FileWorkWithXml(wayToFile);
            List<Figure> figures = file.Read();

            if (figures.Count > 20 || CheckReadingFigures(figures))
            {
                throw new OverflowBoxException("The shape could not be read because a condition was violated: the number of shapes exceeded 20, or the shapes are being repeated.");
            }

            this.Figures = figures;
        }

        /// <summary>
        /// Information about figures in box.
        /// </summary>
        /// <returns>Information about figures in box.</returns>
        public override string ToString()
        {
            string information = null;

            foreach (var figure in Figures)
            {
                information += figure.ToString() + "\n";
            }

            return information;
        }
    }
}
