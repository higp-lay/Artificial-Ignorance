# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [0.8.1] - 2023-09-18

### Fixed
- Improved performance draistically by decreasing runtime for statistics generation

## [0.8.0] - 2023-09-10

### Added
- Search & Replace button & functionality
- Added readability table in PDF report
- Added mispelled word count into popup form & Pdf report
- Added close button to main form

### Changed 
- Changed PDF report format

### Fixed
- Mispelled red lines now shown properly in PDF report
- Words with "'s" not properly splitting 

## [0.7.0] - 2023-09-05

### Added
- Settings to change appearance of window (theme color, font) 
- Settings to change defaults settings of analyzer

### Fixed
- Buttons' BackColor not properly changed in settings page

### Changed
- Labels on buttons to text generated during runtime for visual betterment

## [0.6.0] - 2023-08-30

### Added

- Readability score in Report
- Settings for changing the appearance of the analyzer
- Font size changing buttons
- Beautified the generated report

### Fixed

- Minor bugs that happen during text editing

## [0.5.1] - 2023-08-27

### Added

- Placeholding buttons in settings page
- Page numbers in the generated report

## [0.5.0] - 2023-08-11

### Added

- Word counter beneath the richTextBox
- 3 buttons in Analyzer tab i.e. Left, right and center aligns
- Reintroduced font changing dropdown list

### Fixed

- Certain elements not resizing correctly during window resizing
- Crashes due to FontStyle changing algorithm

## [0.4.1] - 2023-08-10

### Added

- Added author + version on the bottom left corner of window

### Changed

- Algorithm for changing FontStyle (From O(1) to O(n)) 
  for functionality betterment
- Icons/Text shown on FontStyle changing buttons

### Fixed

- User's essay not showing correctly in the PDF report

### Removed

- Has hidden font changing droplist due to bugs

## [0.4.0] - 2023-08-09

### Added

- Button to generate a PDF report with statistics about the essay,
  which can be saved in arbitrary directory
- Functional buttons & droplist to change the FontStyle of text 
  (Added Bold, Italic, Underline, Strikethrough & Font Changing droplist)
- Placeholding settings page
- Title (Artificial Ignorance (AI)) on Home Page
- Save & Import button can now save/import .rtf files
- Resizing of ALL elements with the resizing of window
- A placeholding Python file for access of certain Python module

### Changed

- Backcolor of UserControl to light blue

### Fixed

- Fixed certain UserControls not hiding & showing correctly

### Removed

- MessageBoxes which list the statistics info.

## [0.3.0] - 2023-08-08

### Added

- Import .txt file button
- Functions to generate the essay's statistical info,
  shown by MessageBoxes

### Changed

- Changed all fonts in application to Comic Sans MS

### Fixed

- Files can now be saved in the right directory

## [0.2.0] - 2023-08-07

### Added

- Multiple UserControls for window swapping (i.e. Home page & analyzer page)
- Multiple working buttons on the leftest panel for swapping UserControl 
- Name of analyzer, slogan & image on rightest part of analyzer UserControl page
- Saving text in richTextBox into .txt button

### Changed

- Simple textbox is changed to RichTextBox


## [0.1.0] - 2023-08-06

### Added

- A simple textbox for users to type
- A placeholding simple button 
- A placeholding leftest panel for navigation
- A changelog